using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 血脂
/// </summary>
public class BloodSugarDto
{
    /// <summary>
    /// 档案信息编号
    /// </summary>
    /// <value></value>
    public string ArchivesCode { get; set; }

    /// <summary>
    /// 血糖值
    /// </summary>
    /// <value></value>
    public decimal BloodSugarValue { get; set; }

    /// <summary>
    /// 血糖类型
    /// </summary>
    /// <value></value>
    public BloodSugarTypeEnum BloodSugarType { get; set; } //TODO:需要将枚举转为DispalyName

    /// <summary>
    /// 血糖结果
    /// </summary>
    /// <value></value>
    public BloodSugarResultEnum BloodSugarResultCode { get; set; }

    /// <summary>
    /// 血糖结果
    /// </summary>
    /// <value></value>
    public string BloodSugarResult { get; set; } //TODO:需要将枚举转为DispalyName

    /// <summary>
    /// 健康建议
    /// </summary>
    /// <value></value>
    public string HealthAdvice { get; set; }




}
