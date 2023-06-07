using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 血氧结果枚举
/// </summary>
public enum BloodOxygenResultEnum
{
    /// <summary>
    /// 正常
    /// </summary>
    [Display(Name = "正常")]
    Normal,

    /// <summary>
    /// 轻度异常
    /// </summary>
    [Display(Name = "轻度异常")]
    MildAbnormal,

    /// <summary>
    /// 严重异常
    /// </summary>
    [Display(Name = "严重异常")]
    SevereAbnormal
}