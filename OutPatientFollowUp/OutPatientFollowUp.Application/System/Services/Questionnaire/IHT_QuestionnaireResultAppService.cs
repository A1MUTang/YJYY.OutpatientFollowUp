namespace OutPatientFollowUp.Application;

public interface IHT_QuestionnaireResultAppService : ITransient
{
    /// <summary>
    /// 根据问卷编码获取问卷结果
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<QuestionResultDto> GetQuestionnaireResultByCodeAsync(string code);

    /// <summary>
    /// 保存问卷结果
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Task<bool> SaveQuestionnaireResult(SurveySubmissionDto input);

}