using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 饮食习惯枚举
/// <remarks>
/// Unknown = "不详"
/// BalancedDiet = "荤素均衡"
/// MeatDiet = "荤食为主"
/// VegetarianDiet = "素食为主"
/// MixedDiet = "杂食"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DietHabitsEnum
{
    [Display(Name = "不详")]
    Unknown,
    [Display(Name = "荤素均衡")]
    BalancedDiet,
    [Display(Name = "荤食为主")]
    MeatDiet,
    [Display(Name = "素食为主")]
    VegetarianDiet,
    [Display(Name = "杂食")]
    MixedDiet
}

