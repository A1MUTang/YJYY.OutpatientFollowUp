namespace OutPatientFollowUp.Core;


public class HT_QuestionReuslt
{
    public HT_QuestionReuslt() // 添加公共无参构造函数
    {
    }
    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// 问卷主键
    /// </summary>
    /// <value></value>
    public int QuestionnaireResultId { get; set; }

    /// <summary>
    /// 问题主键
    /// </summary>
    /// <value></value>
    public int QuestionId { get; set; }

    /// <summary>
    /// 问题答案
    /// </summary>
    /// <value></value>
    public string Answers { get; set; }
}



