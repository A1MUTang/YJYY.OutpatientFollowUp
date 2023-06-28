using System;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 问卷结果
/// </summary>
public class HT_QuestionResult
{
    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// 问卷主键
    /// </summary>
    /// <value></value>
    public int QuestionnaireId { get; set; }

    /// <summary>
    /// 基础档案信息Code
    /// </summary>
    /// <value></value>
    public string patientBasicArchivesCode { get; set; }

    /// <summary>
    /// 问卷答案
    /// </summary>
    /// <value></value>
    public string Answers { get; set; }

    /// <summary>
    /// 提交时间
    /// </summary>
    /// <value></value> 
    public DateTime SubmitTime { get; set; }
}



