using System.Text;
using System.Security.Claims;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class ProfileInformationAppService : IProfileInformationAppService
{
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

    private readonly IHT_SupplementaryExamRepository _supplementaryExamRepository;
    private readonly IIdAppService _idAppService;

    public ProfileInformationAppService(IHT_PatientBasicInfoRepository patientBasicInfoRepository, IIdAppService idAppService, IHT_SupplementaryExamRepository supplementaryExamRepository)
    {
        _patientBasicInfoRepository = patientBasicInfoRepository;
        _idAppService = idAppService;
        _supplementaryExamRepository = supplementaryExamRepository;
    }


    public async Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        //判断身份证号是否重复
        var isExist = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(input.IDCardNumber, manageName);
        if (isExist != null)
        {
            throw Oops.Oh("身份证号已存在");
        }
        var basicProfileInformation = input.Adapt<HT_PatientBasicInfo>();
        basicProfileInformation.PBI_UserID = await _idAppService.GetNewManangeID("HT_PatientBasicInfo", "PBI");
        basicProfileInformation.ArchivesCode = basicProfileInformation.PBI_UserID.IndexOf("PBI") != -1
            ? basicProfileInformation.PBI_UserID.Substring(3)
            : basicProfileInformation.PBI_UserID;
        basicProfileInformation.PBI_CreateArchivesUnit = workUnits;
        basicProfileInformation.PBI_ManageUnit = manageName;
        basicProfileInformation.PBI_CreateUserID = doctorId;
        var patientBasicInfo = await _patientBasicInfoRepository.InsertAsync(basicProfileInformation);
        return patientBasicInfo.Adapt<BasicProfileInformationDto>();
    }

    public async Task<ProfileInformationDetailDto> CreateOrUpdateProfileInformationDetailAsync(string archivesCode, CreateOrUpdateProfileInformationDetailDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByArchivesCode(archivesCode, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }

        if (patientBasicInfo.ArchivesCode == archivesCode && patientBasicInfo.PBI_ICard != input.BasicProfileInformation.IDCardNumber)
        {
            //判断身份证号是否重复
            var isExist = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(input.BasicProfileInformation.IDCardNumber, manageName);
            if (isExist != null)
            {
                throw Oops.Oh("身份证号已存在");
            }
        }
        //填充既往病史

        List<int> pastMedicalHistory = input.PastMedicalHistoryCodes.Split(',').Select(int.Parse).ToList();
        // SE_IS_NXG 是否有脑血管病 
        var SE_IS_NXG = pastMedicalHistory.Contains(2) ? "1" : "0";
        // SE_IS_XZJB 是否有心脏疾病 
        var SE_IS_XZJB = pastMedicalHistory.Contains(3) ? "1" : "0";
        // SE_IS_WZXGB 是否有外周血管病 
        var SE_IS_WZXGB = pastMedicalHistory.Contains(4) ? "1" : "0";
        // SE_IS_SWMJB 视网膜疾病 
        var SE_IS_SWMJB = pastMedicalHistory.Contains(5) ? "1" : "0";
        // SE_IS_TNB  糖尿病（Ⅱ型） 
        var SE_IS_TNB = pastMedicalHistory.Contains(6) ? "1" : "0";
        // SE_IS_SB 肾病
        var SE_IS_SB = pastMedicalHistory.Contains(7) ? "1" : "0";
        // SE_IS_Acanthosis 黑棘皮症
        var SE_IS_Acanthosis = pastMedicalHistory.Contains(8) ? "1" : "0";
        // SE_IS_Other 是否有其他 
        var SE_IS_Other = pastMedicalHistory.Contains(9) ? "1" : "0";
        // SE_OtherTxt 其他疾病
        var SE_OtherTxt = input.OtherMedicalHistory;

        await _supplementaryExamRepository.InsertAsync(new HT_SupplementaryExam()
        {
            SE_ID = await _idAppService.GetNewManangeID("HT_SupplementaryExam", "SE"),
            ArchivesCode = archivesCode,
            CreateTime = DateTime.Now,
            SE_IS_NXG = SE_IS_NXG,
            SE_IS_XZJB = SE_IS_XZJB,
            SE_IS_WZXGB = SE_IS_WZXGB,
            SE_IS_SWMJB = SE_IS_SWMJB,
            SE_IS_TNB = SE_IS_TNB,
            SE_IS_SB = SE_IS_SB,
            SE_IS_Acanthosis = SE_IS_Acanthosis,
            SE_IS_Other = SE_IS_Other,
            SE_OtherTxt = SE_OtherTxt
        });

        var updateEntity = input.Adapt<HT_PatientBasicInfo>();
        updateEntity.ArchivesCode = archivesCode;
        var patientBasicInfoDetail = await _patientBasicInfoRepository.UpdateAsync(updateEntity);
        var output = patientBasicInfo.Adapt<ProfileInformationDetailDto>();
        var (pastMedicalHistoryCodes, otherMedicalHistory) = await GetPastMedicalHistoryCodes(archivesCode);

        output.PastMedicalHistoryCodes = pastMedicalHistoryCodes;
        output.PastMedicalHistory = otherMedicalHistory;
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();

    }

    private async Task<(string, string)> GetPastMedicalHistoryCodes(string archivesCode)
    {
        var supplementaryExam = await _supplementaryExamRepository.GetByArchivesCode(archivesCode);
        var pastMedicalHistoryCodes = new StringBuilder();
        var otherMedicalHistory = new StringBuilder();
        if (supplementaryExam.SE_IS_NXG == "1")
        {
            pastMedicalHistoryCodes.Append("2,");
            otherMedicalHistory.Append("脑血管病,");
        }
        if (supplementaryExam.SE_IS_XZJB == "1")
        {
            pastMedicalHistoryCodes.Append("3,");
            otherMedicalHistory.Append("心脏疾病,");
        }
        if (supplementaryExam.SE_IS_WZXGB == "1")
        {
            pastMedicalHistoryCodes.Append("4,");
            otherMedicalHistory.Append("外周血管病,");
        }
        if (supplementaryExam.SE_IS_SWMJB == "1")
        {
            pastMedicalHistoryCodes.Append("5,");
            otherMedicalHistory.Append("视网膜疾病,");
        }
        if (supplementaryExam.SE_IS_TNB == "1")
        {
            pastMedicalHistoryCodes.Append("6,");
            otherMedicalHistory.Append("糖尿病（Ⅱ型）,");
        }
        if (supplementaryExam.SE_IS_SB == "1")
        {
            pastMedicalHistoryCodes.Append("7,");
            otherMedicalHistory.Append("肾病,");
        }
        if (supplementaryExam.SE_IS_Acanthosis == "1")
        {
            pastMedicalHistoryCodes.Append("8,");
            otherMedicalHistory.Append("黑棘皮症,");
        }
        if (supplementaryExam.SE_IS_Other == "1")
        {
            pastMedicalHistoryCodes.Append("9,");
            otherMedicalHistory.Append(supplementaryExam.SE_OtherTxt + ",");
        }
        if (pastMedicalHistoryCodes.Length == 0 && otherMedicalHistory.Length == 0)
        {
            pastMedicalHistoryCodes.Append("0,");
            otherMedicalHistory.Append("未发现,");
        }

        pastMedicalHistoryCodes = pastMedicalHistoryCodes.Remove(pastMedicalHistoryCodes.Length - 1, 1);
        otherMedicalHistory = otherMedicalHistory.Remove(otherMedicalHistory.Length - 1, 1);
        return (pastMedicalHistoryCodes.ToString(), otherMedicalHistory.ToString());
    }

    private (string, string, string) GetLoginInfo()
    {
        var doctorId = App.User?.FindFirstValue("UserID");
        var manageName = App.User?.FindFirstValue("ManageName");
        var workUnits = App.User?.FindFirstValue("WorkUnits");
        return (doctorId, manageName, workUnits);
    }

    public async Task<BasicProfileInformationDto> GetBasicProfileInformationAsync(string IDCardNumber)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(IDCardNumber, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        return patientBasicInfo.Adapt<BasicProfileInformationDto>();
    }

    public async Task<ProfileInformationDetailDto> GetProfileInformationDetailAsync(string archivesCode)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByArchivesCode(archivesCode, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        var output = patientBasicInfo.Adapt<ProfileInformationDetailDto>();
        var (pastMedicalHistoryCodes, otherMedicalHistory) = await GetPastMedicalHistoryCodes(archivesCode);
        output.PastMedicalHistoryCodes = pastMedicalHistoryCodes;
        output.OtherChronicDiseases = otherMedicalHistory;
        return output;
    }

    public async Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(string archivesCode, UpdateBasicProfileInformationDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        var patientBasicInfo = input.Adapt<HT_PatientBasicInfo>();
        patientBasicInfo.ArchivesCode = archivesCode;
        var updateResult = await _patientBasicInfoRepository.UpdateAsync(patientBasicInfo);
        return updateResult.Adapt<BasicProfileInformationDto>();
    }
}