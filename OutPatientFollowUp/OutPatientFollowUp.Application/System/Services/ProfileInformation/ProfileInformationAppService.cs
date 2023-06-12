using System.Security.Claims;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class ProfileInformationAppService : IProfileInformationAppService
{
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

    public ProfileInformationAppService(IHT_PatientBasicInfoRepository patientBasicInfoRepository)
    {
        _patientBasicInfoRepository = patientBasicInfoRepository;
    }


    public async Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input)
    {
        var (doctorId, manageName) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.InsertAsync(input.Adapt<HT_PatientBasicInfo>());
        return patientBasicInfo.Adapt<BasicProfileInformationDto>();
    }

    public async Task<ProfileInformationDetailDto> CreateOrUpdateProfileInformationDetailAsync(string archivesCode,CreateOrUpdateProfileInformationDetailDto input)
    {
        var (doctorId, manageName) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(doctorId, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        patientBasicInfo.PBI_Gender = input.BasicProfileInformation.Gender ? "男" : "女";
        var patientBasicInfoDetail = await _patientBasicInfoRepository.UpdateAsync(patientBasicInfo);
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();

    }
    private (string, string) GetLoginInfo()
    {
        var doctorId = App.User?.FindFirstValue("UserID");
        var manageName = App.User?.FindFirstValue("ManageName");
        return (doctorId, manageName);
    }

    public async Task<BasicProfileInformationDto> GetBasicProfileInformationAsync(string archivesCode)
    {
        var (doctorId, manageName) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(doctorId, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        return patientBasicInfo.Adapt<BasicProfileInformationDto>();
    }

    public async Task<ProfileInformationDetailDto> GetProfileInformationDetailAsync(string archivesCode)
    {
        var (doctorId, manageName) = GetLoginInfo();
        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(doctorId, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();
    }

    public async Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(string archivesCode,UpdateBasicProfileInformationDto input)
    {
        var (doctorId, manageName) = GetLoginInfo();
        var updateResult = await _patientBasicInfoRepository.UpdateAsync(input.Adapt<HT_PatientBasicInfo>());
        return updateResult.Adapt<BasicProfileInformationDto>();
    }
}