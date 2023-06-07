using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 血压结果
/// </summary>
public enum BloodPressureResultEnum
{
    /// <summary>
    /// 低血压
    /// </summary>
    [Display(Name = "低血压")]
    LowBloodPressure,

    /// <summary>
    /// 理想
    /// </summary>
    [Display(Name = "理想")]
    Ideal,

    /// <summary>
    /// 正常
    /// </summary>
    [Display(Name = "正常")]
    Normal,

    /// <summary>
    /// 轻度
    /// </summary>
    [Display(Name = "轻度")]
    Mild,

    /// <summary>
    /// 中度
    /// </summary>
    [Display(Name = "中度")]
    Moderate,

    /// <summary>
    /// 重度
    /// </summary>
    [Display(Name = "重度")]
    Severe
}