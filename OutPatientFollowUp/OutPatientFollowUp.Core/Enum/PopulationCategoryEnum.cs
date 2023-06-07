using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 人群分类枚举
/// <remarks>
/// AT01 = "高龄"
/// AT02 = "老年人"
/// AT03 = "中青年"
/// AT04 = "孕产"
/// AT05 = "儿童"
/// AT06 = "未知"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PopulationCategoryEnum
{
    [Display(Name = "高龄")]
    AT01,
    [Display(Name = "老年人")]
    AT02,
    [Display(Name = "中青年")]
    AT03,
    [Display(Name = "孕产")]
    AT04,
    [Display(Name = "儿童")]
    AT05,
    [Display(Name = "未知")]
    AT06

}

