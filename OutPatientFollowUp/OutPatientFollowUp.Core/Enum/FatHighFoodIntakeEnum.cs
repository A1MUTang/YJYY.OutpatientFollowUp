using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 脂肪含量较高食物摄入量（肉类等）：
/// <remarks>
/// Unknown = "不详"
/// None = "0"
/// LessThanOneLiang = "＜1两"
/// OneToTwoLiang = "1两-2两"
/// TwoToThreeLiang = "2两-3两"
/// ThreeLiangToHalfCatty = "3两-半斤"
/// HalfCattyToOneCatty = "半斤-1斤"
/// OneCattyToTwoCatties = "1斤-2斤"
/// MoreThanTwoCatties = "＞2斤"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FatHighFoodIntakeEnum
{
    /// <summary>
    /// 脂肪含量较高食物摄入量：不详
    /// </summary>
    Unknown,

    /// <summary>
    /// 脂肪含量较高食物摄入量：0
    /// </summary>
    None,

    /// <summary>
    /// 脂肪含量较高食物摄入量：＜1两
    /// </summary>
    LessThanOneLiang,

    /// <summary>
    /// 脂肪含量较高食物摄入量：1两-2两
    /// </summary>
    OneToTwoLiang,

    /// <summary>
    /// 脂肪含量较高食物摄入量：2两-3两
    /// </summary>
    TwoToThreeLiang,

    /// <summary>
    /// 脂肪含量较高食物摄入量：3两-半斤
    /// </summary>
    ThreeLiangToHalfCatty,

    /// <summary>
    /// 脂肪含量较高食物摄入量：半斤-1斤
    /// </summary>
    HalfCattyToOneCatty,

    /// <summary>
    /// 脂肪含量较高食物摄入量：1斤-2斤
    /// </summary>
    OneCattyToTwoCatties,

    /// <summary>
    /// 脂肪含量较高食物摄入量：＞2斤
    /// </summary>
    MoreThanTwoCatties
}

