using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;
public class BloodPressureDto
{
    /// <summary>
    /// 档案信息编号
    /// </summary>
    /// <value></value>
    public string ArchivesCode { get; set; }

    /// <summary>
    /// 收缩压
    /// </summary>
    public int Systolic { get; set; }

    /// <summary>
    /// 舒张压
    /// </summary>
    public int Diastolic { get; set; }

    /// <summary>
    /// 脉搏
    /// </summary>
    public int Pulse { get; set; }

    /// <summary>
    /// 血压结果对应结果码
    /// </summary>
    /// <value></value>
    public BloodPressureResultEnum bloodPressureResultCode { get; set; }

    /// <summary>
    /// 血压结果
    /// </summary>
    /// <value></value>
    public string bloodPressureResult { get; set; }

    /// <summary>
    /// 脉搏结果对应结果码
    /// </summary>
    /// <value></value>
    public HeartRateResultEnum HeartRateResultCode { get; set; }

    /// <summary>
    /// 脉搏结果
    /// </summary>
    /// <value></value>
    public string HeartRateResult { get; set; }

    /// <summary>
    /// 健康建议    
    /// </summary>
    /// <value></value>
    public string HealthAdvice { get; set; }
}