using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 饮酒状况枚举
/// <remarks>
/// Unknown = "不详"
/// Never = "从不饮酒"
/// Quit = "已戒酒"
/// Regular = "饮酒"
/// </remarks>
/// </summary>
public enum AlcoholStatusEnum
{
    [Display(Name = "不详")]
    Unknown,
    [Display(Name = "从不饮酒")]
    Never,
    [Display(Name = "已戒酒")]
    Quit,
    [Display(Name = "饮酒")]
    Regular
}


