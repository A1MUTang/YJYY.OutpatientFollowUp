namespace OutPatientFollowUp.Application.HealthMonitor;
public class BloodOxygenDto
{
    /// <summary>
    /// 血氧值
    /// </summary>
    /// <remarks>单位：%</remarks>
    /// <value></value>
    public int BloodOxygenValue { get; set; }
    /// <summary>
    /// 基础档案信息主键
    /// </summary>
    /// <value></value>
    public Guid BasicProfileInformationId { get; set; }
    /// <summary>
    /// 健康基础信息
    /// </summary>
    /// <remarks>测量结果中的抬头</remarks>
    /// <value></value>
    public HealthMonitorBaseDto HealthMonitorBaseDto { get; set; }
    
    /// <summary>
    /// 血氧结果
    /// </summary>
    /// <remarks>单位：%</remarks>
    /// <value></value>
    public string BloodOxygenResult { get; set; }

}