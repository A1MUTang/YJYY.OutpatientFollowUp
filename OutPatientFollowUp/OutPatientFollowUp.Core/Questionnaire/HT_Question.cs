using System.Collections.Generic;
using SqlSugar;

namespace OutPatientFollowUp.Core;
public class HT_Question
{
    /// <summary>
    /// 问题主键
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// 问卷主键
    /// </summary>
    /// <value></value>
    public int QuestionnaireId { get; set; }

    /// <summary>
    /// 问题题干
    /// </summary>
    /// <value></value>
    public string Title { get; set; }

    /// <summary>
    /// 问题类型
    /// </summary>
    /// <value></value>
    public SurveyQuestionTypeEnum Type { get; set; }

    /// <summary>
    /// 问题选项
    /// </summary>
    /// <value></value>
    [SugarColumn(IsIgnore = true)]
    public virtual ICollection<HT_Options> Options { get; set; }
}
