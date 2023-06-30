using SqlSugar;

namespace OutPatientFollowUp.Core;


public class HT_QuestionResult
{
    public HT_QuestionResult() // 添加公共无参构造函数
    {
    }
    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
    public int Id { get; set; }

    /// <summary>
    /// 问卷结果主键
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
    public string Answer { get; set; }
}