
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class QuestionnaireMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<QuestionnaireDto, HT_Questionnaire>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.EstimatedTime, src => src.EstimatedTime)
            .Map(dest => dest.Questions, src => src.Questions);

        config.ForType<QuestionDto, HT_Question_OutPatientFollowUp>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Options, src => src.Options);

        config.ForType<OptionsDto, HT_Option>()
            .Map(dest => dest.Content, src => src.Content);

    }
}