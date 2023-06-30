using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class HT_QuestionnaireResultAppService : IHT_QuestionnaireResultAppService
{
    private readonly IHT_QuestionnaireResultRepository _questionnaireResultRepository;

    public HT_QuestionnaireResultAppService(IHT_QuestionnaireResultRepository questionnaireResultRepository)
    {
        _questionnaireResultRepository = questionnaireResultRepository;
    }

    public async Task<QuestionResultDto> GetQuestionnaireResultByCodeAsync(string code, string patientBasicArchivesCode)
    {
        var questionnaireResult = await _questionnaireResultRepository.GetQuestionnaireResultByCodeAsync(code, patientBasicArchivesCode);
        var result = questionnaireResult.Adapt<QuestionResultDto>();
          result =   questionnaireResult.QuestionResults.Adapt<QuestionResultDto>();
        return result;
    }

    public async Task<bool> SaveQuestionnaireResult(SurveySubmissionDto input)
    {
        return await _questionnaireResultRepository.SaveQuestionnaireResult(input.Adapt<HT_QuestionnaireResult>());
    }
}