namespace OutPatientFollowUp.Core;

public interface IHT_QuestionnaireResultAppService : ITransient
{
    /// <summary>
    /// 根据问卷编码获取问卷结果
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<HT_QuestionnaireResult> GetQuestionnaireResultByCodeAsync(string code);

    /// <summary>
    /// 保存问卷结果
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Task<bool> SaveQuestionnaireResult(HT_QuestionnaireResult input);
}