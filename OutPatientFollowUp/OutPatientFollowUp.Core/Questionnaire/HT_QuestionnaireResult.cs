using System;
using System.Collections.Generic;
using SqlSugar;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 问卷结果
/// </summary>
public class HT_QuestionnaireResult
{

    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
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
    public string PatientBasicArchivesCode { get; set; }

    /// <summary>
    /// 提交时间
    /// </summary>
    /// <value></value> 
    public DateTime SubmitTime { get; set; } = DateTime.Now;


    /// <summary>
    /// 问卷问题
    /// </summary>
    /// <value></value>
    [SugarColumn(IsIgnore = true)]
    public virtual IList<HT_QuestionResult> QuestionResults { get; set; }
}
