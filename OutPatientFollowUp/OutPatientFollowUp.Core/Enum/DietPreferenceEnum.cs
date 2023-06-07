using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 饮食口味枚举
/// <remarks>
/// Moderate = "适中"
/// SaltLover = "嗜盐"
/// SweetTooth = "嗜甜"
/// GreasyFood = "嗜油"
/// Light = "清淡"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DietPreferenceEnum
{
    [Display(Name = "适中")]
    Moderate,
    [Display(Name = "嗜盐")]
    SaltLover,
    [Display(Name = "嗜甜")]
    SweetTooth,
    [Display(Name = "嗜油")]
    GreasyFood,
    [Display(Name = "清淡")]
    Light
}

