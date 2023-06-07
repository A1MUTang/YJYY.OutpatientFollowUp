using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 目标脂肪含量较高食物摄入量枚举
/// <remarks>
/// Unknown = "不详"
/// None = "0"
/// LessThanOneLiang = "＜1两"
/// OneToTwoLiang = "1两-2两"
/// TwoToThreeLiang = "2两-3两"
/// ThreeLiangToHalfCatty = "3两-半斤"
/// HalfCattyToOneCatty = "半斤-1斤"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HighFatFoodIntakeEnum
{
    [Display(Name = "不详")]
    Unknown,

    [Display(Name = "0")]
    None,

    [Display(Name = "＜1两")]
    LessThanOneLiang,

    [Display(Name = "1两-2两")]
    OneToTwoLiang,

    [Display(Name = "2两-3两")]
    TwoToThreeLiang,

    [Display(Name = "3两-半斤")]
    ThreeLiangToHalfCatty,

    [Display(Name = "半斤-1斤")]
    HalfCattyToOneCatty,

}
