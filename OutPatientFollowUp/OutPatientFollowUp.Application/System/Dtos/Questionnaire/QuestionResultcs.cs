namespace OutPatientFollowUp;

public class QuestionResultcs
{
    /// <summary>
    /// 问卷标题
    /// </summary>
    /// <value></value>
    public string Title { get; set; }

    /// <summary>
    /// 问卷编号
    /// </summary>
    /// <value></value>
    public string Code { get; set; }

    /// <summary>
    /// 问卷结果图形Code
    /// </summary>
    /// <remark>
    /// 脑卒中风险评估 
    /// 低危 = 0，
    /// 中危 = 1，
    /// 高危 = 2，
    /// 心血管风险评估
    /// 低危 = 0，
    /// 中危 = 1，
    /// 高危 = 2，
    /// 极高危 = 3，
    /// 慢阻肺风险评估
    /// 如有呼吸问题可咨询医生 = 0，
    /// 呼吸问题可能是慢阻肺导致 = 1，
    /// 糖尿病风险评估
    /// 非高风险 = 0，
    /// 高风险 = 1，
    /// </remark>
    /// <value></value>
    public string ResultCode { get; set; }

    /// <summary>
    /// 问卷结果(评估结果)
    /// </summary>
    /// <value></value>
    public string Result { get; set; }

    /// <summary>
    /// 健康建议
    /// </summary>
    /// <value></value>
    public string HealthAdvice { get; set; }



}