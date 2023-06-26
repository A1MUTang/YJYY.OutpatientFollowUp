using OutPatientFollowUp.Core;

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
    public string ArchivesCode { get; set; }

    /// <summary>
    /// 血氧结果
    /// </summary>
    /// <remarks>单位：%</remarks>
    /// <value></value>
    public BloodOxygenResultEnum BloodOxygenResultCode { get; set; }

    /// <summary>
    /// 血氧结果
    /// </summary>
    /// <remarks>单位：%</remarks>
    /// <value></value>
    public string BloodOxygenResult { get; set; }

}