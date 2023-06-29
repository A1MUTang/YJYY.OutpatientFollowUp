using System.Collections.Generic;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_Questionnaire
{
    /// <summary>
    /// 问卷主键
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// 问卷标题
    /// </summary>
    /// <value></value>
    public string Title { get; set; }

    /// <summary>
    /// 问卷代码
    /// </summary>
    /// <value></value>
    public string Code { get; set; }

    /// <summary>
    /// 问卷描述
    /// </summary>
    /// <value></value>
    public string Description { get; set; }

    /// <summary>
    /// 预计完成时间
    /// </summary>
    /// <remarks>单位：分钟</remarks>   
    /// <value></value>
    public int EstimatedTime { get; set; }

    /// <summary>
    /// 问卷问题
    /// </summary>
    /// <value></value>
    [SugarColumn(IsIgnore = true)]
    public virtual ICollection<HT_Question_OutPatientFollowUp> Questions { get; set; }

}