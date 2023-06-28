namespace OutPatientFollowUp.Application;

/// <summary>
/// 问卷提交 DTO
/// </summary>
public class SurveySubmissionDto
{
    /// <summary>
    /// 问卷 ID
    /// </summary>
    /// <value></value>
    public string QuestionnaireCode { get; set; }

    /// <summary>
    /// 问题提交列表
    /// </summary>
    /// <value></value>
    public List<QuestionSubmissionDto> QuestionSubmissions { get; set; }

    /// <summary>
    /// 患者基础档案Code
    /// </summary>
    /// <value></value>
    public string PatientBasicArchivesCodeArchivesCode { get; set; }
}

/// <summary>
/// 问题提交 DTO
/// </summary>
public class QuestionSubmissionDto
{
    /// <summary>
    /// 问题 ID
    /// </summary>
    /// <value></value>
    public string QuestionId { get; set; }

    /// <summary>
    /// 答案文本
    /// </summary>
    /// <value></value>
    public string AnswerText { get; set; }
}