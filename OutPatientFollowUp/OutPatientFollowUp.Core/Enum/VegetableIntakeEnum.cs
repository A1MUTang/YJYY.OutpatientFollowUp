using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 蔬菜摄入量枚举
/// <remarks>
/// Unknown = "不详"
/// LowIntake = "摄入量小"
/// HighIntake = "摄入量大"
/// ModerateIntake = "摄入量适中"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VegetableIntakeEnum
{
    [Display(Name = "不详")]
    Unknown,
    [Display(Name = "摄入量小")]
    LowIntake,
    [Display(Name = "摄入量大")]
    HighIntake,
    [Display(Name = "摄入量适中")]
    ModerateIntake
}

