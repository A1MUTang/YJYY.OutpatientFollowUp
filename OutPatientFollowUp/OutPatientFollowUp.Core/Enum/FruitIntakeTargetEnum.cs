using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 目标蔬菜摄入量枚举
/// <remarks>
/// Unknown = "不详"
/// HalfToOneKilogram = "半斤到一斤"
/// OneToOneAndHalfKilograms = "一斤到一斤半"
/// OneAndHalfToTwoKilograms = "一斤半到二斤"
/// TwoToThreeKilograms = "两斤到三斤"
/// MoreThanThreeKilograms = "三斤以上"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FruitIntakeTargetEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    [Display(Name = "不详")]
    Unknown,

    /// <summary>
    /// 半斤到一斤
    /// </summary>
    [Display(Name = "半斤到一斤")]
    HalfToOneKilogram,

    /// <summary>
    /// 一斤到一斤半
    /// </summary>
    [Display(Name = "一斤到一斤半")]
    OneToOneAndHalfKilograms,

    /// <summary>
    /// 一斤半到二斤
    /// </summary>
    [Display(Name = "一斤半到二斤")]
    OneAndHalfToTwoKilograms,

    /// <summary>
    /// 两斤到三斤
    /// </summary>
    [Display(Name = "两斤到三斤")]
    TwoToThreeKilograms,

    /// <summary>
    /// 三斤以上
    /// </summary>
    [Display(Name = "三斤以上")]
    MoreThanThreeKilograms
}

