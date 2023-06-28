namespace OutPatientFollowUp.Core;

public class HT_QuestionnaireResultAppService : IHT_QuestionnaireResultAppService
{
    private readonly IHT_QuestionnaireResultRepository _questionnaireResultRepository;

    public HT_QuestionnaireResultAppService(IHT_QuestionnaireResultRepository questionnaireResultRepository)
    {
        _questionnaireResultRepository = questionnaireResultRepository;
    }

    public async Task<HT_QuestionnaireResult> GetQuestionnaireResultByCodeAsync(string code)
    {
        return await _questionnaireResultRepository.GetQuestionnaireResultByCodeAsync(code);
    }

    public async Task<bool> SaveQuestionnaireResult(HT_QuestionnaireResult input)
    {
        return await _questionnaireResultRepository.SaveQuestionnaireResult(input);
    }
}