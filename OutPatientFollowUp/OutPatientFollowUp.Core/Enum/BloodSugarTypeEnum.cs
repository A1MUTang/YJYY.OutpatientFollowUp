
using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 血糖类型
/// <remarks>
/// Fasting = "空腹"
/// Postprandial = "餐后"
/// Random = "随机"
/// </remarks>
/// </summary>
public enum BloodSugarTypeEnum
{
    /// <summary>
    /// 空腹血糖
    /// </summary>
    [Display(Name = "空腹血糖")]
    Fasting,

    /// <summary>
    /// 餐后血糖
    /// </summary>
    [Display(Name = "餐后血糖")]
    Postprandial,

    /// <summary>
    /// 随机血糖
    /// </summary>
    [Display(Name = "随机血糖")]
    Random,
}