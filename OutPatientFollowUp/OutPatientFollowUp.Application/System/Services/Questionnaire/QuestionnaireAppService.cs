using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class QuestionnaireAppService : IQuestionnaireAppService
{
    private readonly IHT_QuestionnaireRepository _questionnaireRepository;

    public QuestionnaireAppService(IHT_QuestionnaireRepository questionnaireRepository)
    {
        _questionnaireRepository = questionnaireRepository;
    }

    public async Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code)
    {
        return await _questionnaireRepository.GetQuestionnaireByCodeAsync(code);
    }
}