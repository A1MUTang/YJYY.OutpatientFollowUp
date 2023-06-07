
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
public enum BloodSugarType
{
    [Display(Name = "空腹")]
    Fasting,
    [Display(Name = "餐后")]
    Postprandial,
    [Display(Name = "随机")]
    Random
}