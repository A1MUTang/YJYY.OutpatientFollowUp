using System.Text;
using System.Security.Claims;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class ProfileInformationAppService : IProfileInformationAppService
{
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;
    private readonly IHT_SupplementaryExamRepository _supplementaryExamRepository;
    private readonly IIdAppService _idAppService;
    private readonly IPT_DoctorBasicInfoRepositroy _doctorBasicInfoRepositroy;

    public ProfileInformationAppService(IHT_PatientBasicInfoRepository patientBasicInfoRepository,
    IIdAppService idAppService, IHT_SupplementaryExamRepository supplementaryExamRepository,
    IPT_DoctorBasicInfoRepositroy doctorBasicInfoRepositroy)
    {
        _patientBasicInfoRepository = patientBasicInfoRepository;
        _idAppService = idAppService;
        _supplementaryExamRepository = supplementaryExamRepository;
        _doctorBasicInfoRepositroy = doctorBasicInfoRepositroy; ;
    }


    public async Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        //判断身份证号是否重复
        var isExist = await _patientBasicInfoRepository.GetByIdCardAndDoctorIdAsync(input.IDCardNumber, manageName);
        if (isExist != null)
        {
            throw Oops.Bah("身份证号已存在", new AbandonedMutexException("身份证号已存在"));
        }
        var basicProfileInformation = input.Adapt<HT_PatientBasicInfo>();
        basicProfileInformation.PBI_UserID = await _idAppService.GetNewManangeID("HT_PatientBasicInfo", "PBI");
        basicProfileInformation.ArchivesCode = basicProfileInformation.PBI_UserID.IndexOf("PBI") != -1
            ? basicProfileInformation.PBI_UserID.Substring(3)
            : basicProfileInformation.PBI_UserID;
        basicProfileInformation.PBI_CreateArchivesUnit = workUnits;
        basicProfileInformation.PBI_ManageUnit = manageName;
        basicProfileInformation.PBI_CreateUserID = doctorId;
        basicProfileInformation.PBI_CreateDate = DateTime.Now;
        basicProfileInformation.PBI_CreateUser = await _doctorBasicInfoRepositroy.GetDoctorName(doctorId);//我不知道这个冗余字段的意义，但是我还是加上了
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
            var isExist = await _patientBasicInfoRepository.GetByIdCardAndDoctorIdAsync(input.BasicProfileInformation.IDCardNumber, manageName);
            if (isExist != null)
            {
                throw Oops.Oh("身份证号已存在");
            }
        }
        //填充既往病史
        if (!string.IsNullOrEmpty(input.PastMedicalHistoryCodes) || !string.IsNullOrEmpty(input.OtherMedicalHistory))
        {

            List<int> pastMedicalHistorys = !string.IsNullOrEmpty(input.PastMedicalHistoryCodes)? input.PastMedicalHistoryCodes.Split(',').Select(int.Parse).ToList() : new List<int>();
            // SE_IsDisease 是否有疾病
            var SE_IsDisease = pastMedicalHistorys.Contains(0) ? "1" : "0";
            // SE_IS_GXY 是否有高血压
            var SE_IS_GXY = pastMedicalHistorys.Contains(1) ? "1" : "0";
            // SE_IS_NXG 是否有脑血管病 
            var SE_IS_NXG = pastMedicalHistorys.Contains(2) ? "1" : "0";
            // SE_IS_XZJB 是否有心脏疾病 
            var SE_IS_XZJB = pastMedicalHistorys.Contains(3) ? "1" : "0";
            // SE_IS_WZXGB 是否有外周血管病 
            var SE_IS_WZXGB = pastMedicalHistorys.Contains(4) ? "1" : "0";
            // SE_IS_SWMJB 视网膜疾病 
            var SE_IS_SWMJB = pastMedicalHistorys.Contains(5) ? "1" : "0";
            // SE_IS_TNB  糖尿病（Ⅱ型） 
            var SE_IS_TNB = pastMedicalHistorys.Contains(6) ? "1" : "0";
            // SE_IS_SB 肾病
            var SE_IS_SB = pastMedicalHistorys.Contains(7) ? "1" : "0";
            // SE_IS_PCOS 多囊卵巢综合征（PCOS）
            var SE_IS_PCOS = pastMedicalHistorys.Contains(8) ? "1" : "0";
            // SE_IS_GestationalDiabetes 妊娠糖尿病史
            var SE_IS_GestationalDiabetes = pastMedicalHistorys.Contains(9) ? 1 : 0;
            // SE_IS_Acanthosis 黑棘皮症
            var SE_IS_Acanthosis = pastMedicalHistorys.Contains(10) ? "1" : "0";

            // SE_IS_Other 是否有其他 
            var SE_IS_Other = !string.IsNullOrEmpty(input.OtherMedicalHistory) ? "1" : "0";
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
                SE_IS_GXY = SE_IS_GXY,
                SE_IS_PCOS = SE_IS_PCOS,
                SE_IsDisease = SE_IsDisease,
                IsGestational = SE_IS_GestationalDiabetes,
                SE_IS_Acanthosis = SE_IS_Acanthosis,
                SE_IS_Other = SE_IS_Other,
                SE_OtherTxt = SE_OtherTxt
            });
        }
        else
        {
            await _supplementaryExamRepository.InsertAsync(new HT_SupplementaryExam()
            {
                SE_ID = await _idAppService.GetNewManangeID("HT_SupplementaryExam", "SE"),
                ArchivesCode = archivesCode,
                CreateTime = DateTime.Now
            });
        }

        var updateEntity = input.Adapt<HT_PatientBasicInfo>();
        updateEntity.ArchivesCode = archivesCode;
        var patientBasicInfoDetail = await _patientBasicInfoRepository.UpdateAsync(updateEntity);
        var output = patientBasicInfo.Adapt<ProfileInformationDetailDto>();
        var (pastMedicalHistoryCodes, pastMedicalHistory, otherMedicalHistory) = await GetPastMedicalHistoryCodes(archivesCode);
        output.OtherMedicalHistory = otherMedicalHistory;
        output.PastMedicalHistoryCodes = pastMedicalHistoryCodes;
        output.PastMedicalHistory = pastMedicalHistory;
        return output;

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
        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdCardAndDoctorIdAsync(IDCardNumber, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Bah("患者基本信息不存在");
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
        var (pastMedicalHistoryCodes, pastMedicalHistory, otherMediclHistory) = await GetPastMedicalHistoryCodes(archivesCode);
        output.PastMedicalHistoryCodes = pastMedicalHistoryCodes;
        output.PastMedicalHistory = pastMedicalHistory;
        output.OtherMedicalHistory = otherMediclHistory;
        return output;
    }

    public async Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(string archivesCode, UpdateBasicProfileInformationDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        var patientBasicInfo = input.Adapt<HT_PatientBasicInfo>();
        patientBasicInfo.ArchivesCode = archivesCode;
        patientBasicInfo.PBI_CreateUser = await _doctorBasicInfoRepositroy.GetDoctorName(doctorId);
        patientBasicInfo.PBI_CreateUserID = doctorId;//我同样不知道为什么CreateUserID会在修改的时候填充
        var updateResult = await _patientBasicInfoRepository.UpdateBasicInfoAsync(patientBasicInfo);
        return updateResult.Adapt<BasicProfileInformationDto>();
    }


    private async Task<(string, string, string)> GetPastMedicalHistoryCodes(string archivesCode)
    {
        var supplementaryExam = await _supplementaryExamRepository.GetByArchivesCode(archivesCode);
        if (supplementaryExam == null)
        {
            return ("", "", "");
        }
        var pastMedicalHistoryCodes = new StringBuilder();
        var pastMedicalHistory = new StringBuilder();

        if (supplementaryExam.SE_IsDisease == "1")
        {
            pastMedicalHistoryCodes.Append("0,");
            pastMedicalHistory.Append("未发现,");
        }
        
        if (supplementaryExam.SE_IS_GXY == "1")
        {
            pastMedicalHistoryCodes.Append("1,");
            pastMedicalHistory.Append("高血压,");
        }
        if (supplementaryExam.SE_IS_NXG == "1")
        {
            pastMedicalHistoryCodes.Append("2,");
            pastMedicalHistory.Append("脑血管病,");
        }
        if (supplementaryExam.SE_IS_XZJB == "1")
        {
            pastMedicalHistoryCodes.Append("3,");
            pastMedicalHistory.Append("心脏疾病,");
        }
        if (supplementaryExam.SE_IS_WZXGB == "1")
        {
            pastMedicalHistoryCodes.Append("4,");
            pastMedicalHistory.Append("外周血管病,");
        }
        if (supplementaryExam.SE_IS_SWMJB == "1")
        {
            pastMedicalHistoryCodes.Append("5,");
            pastMedicalHistory.Append("视网膜疾病,");
        }
        if (supplementaryExam.SE_IS_TNB == "1")
        {
            pastMedicalHistoryCodes.Append("6,");
            pastMedicalHistory.Append("糖尿病（Ⅱ型）,");
        }
        if (supplementaryExam.SE_IS_SB == "1")
        {
            pastMedicalHistoryCodes.Append("7,");
            pastMedicalHistory.Append("肾病,");
        }
        if (supplementaryExam.SE_IS_PCOS == "1")
        {
            pastMedicalHistoryCodes.Append("8,");
            pastMedicalHistory.Append("多囊卵巢综合征（PCOS）,");
        }
        if (supplementaryExam.IsGestational == 1)
        {
            pastMedicalHistoryCodes.Append("9,");
            pastMedicalHistory.Append("妊娠糖尿病史,");
        }
        if (supplementaryExam.SE_IS_Acanthosis == "1")
        {
            pastMedicalHistoryCodes.Append("10,");
            pastMedicalHistory.Append("黑棘皮症,");
        }
        if (pastMedicalHistoryCodes.Length != 0 && pastMedicalHistory.Length != 0)
        {
            pastMedicalHistoryCodes = pastMedicalHistoryCodes.Remove(pastMedicalHistoryCodes.Length - 1, 1);
            pastMedicalHistory = pastMedicalHistory.Remove(pastMedicalHistory.Length - 1, 1);
        }
        return (pastMedicalHistoryCodes.ToString(), pastMedicalHistory.ToString(), supplementaryExam.SE_OtherTxt);
    }

}