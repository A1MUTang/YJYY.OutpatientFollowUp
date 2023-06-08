namespace OutPatientFollowUp.Application;

public class ProfileInformationAppService : IProfileInformationAppService
{
    public Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input)
    {
        throw new NotImplementedException();
    }

    public Task<ProfileInformationDetailDto> CreateOrUpdateProfileInformationDetailAsync(CreateOrUpdateProfileInformationDetailDto input)
    {
        throw new NotImplementedException();
    }

    public Task<BasicProfileInformationDto> GetBasicProfileInformationAsync(string archivesCode)
    {
        throw new NotImplementedException();
    }

    public Task<ProfileInformationDetailDto> GetProfileInformationDetailAsync(string archivesCode)
    {
        throw new NotImplementedException();
    }

    public Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(UpdateBasicProfileInformationDto input)
    {
        throw new NotImplementedException();
    }
}