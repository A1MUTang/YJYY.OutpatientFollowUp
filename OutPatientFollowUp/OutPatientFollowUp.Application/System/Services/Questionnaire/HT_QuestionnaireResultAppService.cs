using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class HT_QuestionnaireResultAppService : IHT_QuestionnaireResultAppService
{
    private readonly IHT_QuestionnaireResultRepository _questionnaireResultRepository;

    public HT_QuestionnaireResultAppService(IHT_QuestionnaireResultRepository questionnaireResultRepository)
    {
        _questionnaireResultRepository = questionnaireResultRepository;
    }

    public async Task<QuestionResultDto> GetQuestionnaireResultByCodeAsync(string code)
    {
       var result =  await _questionnaireResultRepository.GetQuestionnaireResultByCodeAsync(code);
        return result.Adapt<QuestionResultDto>();
    }

    public async Task<bool> SaveQuestionnaireResult(SurveySubmissionDto input)
    {
        return await _questionnaireResultRepository.SaveQuestionnaireResult(input.Adapt<HT_QuestionnaireResult>());
    }
}