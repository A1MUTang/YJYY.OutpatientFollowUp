using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 婚姻状况枚举
/// <remarks>
/// Single = "未婚"
/// Married = "已婚"
/// Divorced = "离异"
/// Widowed = "丧偶"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MaritalStatusEnum
{

    [Display(Name = "未婚")]
    Single,
    [Display(Name = "已婚")]
    Married,
    [Display(Name = "离异")]
    Divorced,
    [Display(Name = "丧偶")]
    Widowed
}
