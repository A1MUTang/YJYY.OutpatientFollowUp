using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 睡眠时间
/// <remarks>
/// Unknown = "不详"
/// LessThanSixHours = "＜6小时"
/// SixToSevenHours = "6-7小时"
/// SevenToEightHours = "7-8小时"
/// EightToNineHours = "8-9小时"
/// NineToTenHours = "9-10小时"
/// MoreThanTenHours = "＞10小时"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SleepDurationEnum
{
    [Display(Name = "不详")]
    Unknown,

    [Display(Name = "＜6小时")]
    LessThanSixHours,

    [Display(Name = "6-7小时")]
    SixToSevenHours,

    [Display(Name = "7-8小时")]
    SevenToEightHours,

    [Display(Name = "8-9小时")]
    EightToNineHours,

    [Display(Name = "9-10小时")]
    NineToTenHours,

    [Display(Name = "＞10小时")]
    MoreThanTenHours
}
