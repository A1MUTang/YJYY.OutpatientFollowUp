using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DoctorinfoDto, PT_DoctorBasicInfo>()
                .Map(dest => dest.Doctor_ID, src => src.ID)
                .Map(dest => dest.Doctor_ImgPath, src => src.ImgPath)
                .Map(dest => dest.Doctor_Gender, src => src.Gender)
                .Map(dest => dest.Doctor_UserName, src => src.UserName);
        config.ForType<CreateBasicProfileInformationDto, HT_PatientBasicInfo>()
                .Map(dest => dest.PBI_UserName, src => src.Name)
                .Map(dest => dest.PBI_Address, src => src.Address)
                .Map(dest => dest.PBI_Address, src => src.CurrentAddress)
                .Map(dest => dest.PBI_ICard, src => src.IDCardNumber)
                // .Map(dest => dest.PBI_IsAntidepressant, src => src.IsTakingAntidiabeticMeds) //TODO 未确认字段
                // .Map(dest => dest.PBI_IsAntipsychotics, src => src.IsTakingAntihypertensiveMeds) //TODO 未确认字段
                .Map(dest => dest.PBI_PersonPhone, src => src.PhoneNumber)
                .Map(dest => dest.PBI_Gender, src => src.Gender);
    }
}
