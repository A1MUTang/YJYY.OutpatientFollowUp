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
        var patientBasicInfo = await _patientBasicInfoRepository.InsertAsync(input.Adapt<HT_PatientBasicInfo>());
        return patientBasicInfo.Adapt<BasicProfileInformationDto>();
    }

    public async Task<ProfileInformationDetailDto> CreateOrUpdateProfileInformationDetailAsync(CreateOrUpdateProfileInformationDetailDto input, string doctorId, string manageName)
    {

        var patientBasicInfo = await _patientBasicInfoRepository.GetByIdcardAndDocterIdAsync(doctorId, manageName);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("患者基本信息不存在");
        }
        patientBasicInfo.PBI_Gender = input.BasicProfileInformation.Gender? "男":"女";
        var patientBasicInfoDetail = await _patientBasicInfoRepository.UpdateAsync(patientBasicInfo);
        return patientBasicInfo.Adapt<ProfileInformationDetailDto>();

    }

    public async Task<BasicProfileInformationDto> GetBasicProfileInformationAsync(string archivesCode)
    {
        throw new NotImplementedException();
    }

    public async Task<ProfileInformationDetailDto> GetProfileInformationDetailAsync(string archivesCode)
    {
        throw new NotImplementedException();
    }

    public async Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(UpdateBasicProfileInformationDto input)
    {
        throw new NotImplementedException();
    }
}