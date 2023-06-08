namespace OutPatientFollowUp.Application;

public class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DoctorinfoDto, DoctorinfoDto>()
                .Map(dest =>dest.ID, src => src.ID)
                .Map(dest =>dest.ImgPath, src => src.ImgPath)
                .Map(dest =>dest.Gender,src=>src.Gender)
                .Map(dest =>dest.UserName,src=>src.UserName);
    }
}
