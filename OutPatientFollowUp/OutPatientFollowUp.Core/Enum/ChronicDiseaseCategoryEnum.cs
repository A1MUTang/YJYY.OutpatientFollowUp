using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 慢病分类枚举
/// <remarks>
/// Hypertension = "高血压"
/// Diabetes = "糖尿病"
/// Dyslipidemia = "血脂异常"
/// CoronaryHeartDisease = "冠心病"
/// Stroke = "脑卒中"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChronicDiseaseCategoryEnum
{
    [Display(Name = "高血压")]
    Hypertension,
    [Display(Name = "糖尿病")]
    Diabetes,
    [Display(Name = "血脂异常")]
    Dyslipidemia,
    [Display(Name = "冠心病")]
    CoronaryHeartDisease,
    [Display(Name = "脑卒中")]
    Stroke
}

