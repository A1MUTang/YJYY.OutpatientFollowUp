using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class QuestionnaireAppService : IQuestionnaireAppService
{
    private readonly IHT_QuestionnaireRepository _questionnaireRepository;

    public QuestionnaireAppService(IHT_QuestionnaireRepository questionnaireRepository)
    {
        _questionnaireRepository = questionnaireRepository;
    }

    public async Task<QuestionnaireDto> GetQuestionnaireByCodeAsync(string code)
    {
        var result = await _questionnaireRepository.GetQuestionnaireByCodeAsync(code);
        return  result.Adapt<QuestionnaireDto>();
    }
}