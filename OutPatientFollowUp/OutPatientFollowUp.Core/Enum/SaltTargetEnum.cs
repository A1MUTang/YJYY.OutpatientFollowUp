using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 控盐目标枚举
/// <remarks>
/// LessThan2Grams = "&lt;2克"
/// TwoToFourGrams = "2-4克"
/// FourToSixGrams = "4-6克"
/// SixToEightGrams = "6-8克"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SaltTargetEnum
{
    [Display(Name = "<2克")]
    LessThan2Grams,
    [Display(Name = "2-4克")]
    TwoToFourGrams,
    [Display(Name = "4-6克")]
    FourToSixGrams,
    [Display(Name = "6-8克")]
    SixToEightGrams
}

