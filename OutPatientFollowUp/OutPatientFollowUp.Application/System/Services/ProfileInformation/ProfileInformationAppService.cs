using System.Security.Claims;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class ProfileInformationAppService : IProfileInformationAppService
{
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;
    private readonly IIdAppService _idAppService;

    public ProfileInformationAppService(IHT_PatientBasicInfoRepository patientBasicInfoRepository, IIdAppService idAppService)
    {
        _patientBasicInfoRepository = patientBasicInfoRepository;
        _idAppService = idAppService;
    }


    public async Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input)
    {
        var (doctorId, manageName, workUnits) = GetLoginInfo();
        //判断身份证号是否重复
        var isExist = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(input.IDCardNumber, manageName);
        if (isExist != null)
        {
            throw  Oops.Oh("身份证号已存在");
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
        patientBasicInfo.PBI_Gender = input.BasicProfileInformation.Gender ? "男" : "女";
        var patientBasicInfoDetail = await _patientBasicInfoRepository.UpdateAsync(patientBasicInfo);
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();

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
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();
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