using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 吸烟状况枚举
/// <remarks>
/// Unknown = "不详"
/// NeverSmoked = "从不吸烟"
/// QuitSmoking = "已戒烟"
/// Smoking = "吸烟"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SmokingStatusEnum
{
    [Display(Name = "不详")]
    Unknown,
    [Display(Name = "从不吸烟")]
    NeverSmoked,
    [Display(Name = "已戒烟")]
    QuitSmoking,
    [Display(Name = "吸烟")]
    Smoking
}



