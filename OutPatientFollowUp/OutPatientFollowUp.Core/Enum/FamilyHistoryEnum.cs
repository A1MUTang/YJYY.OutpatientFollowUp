using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 家族史枚举
/// <remarks>
/// Hypertension = "高血压"
/// CoronaryHeartDisease = "冠心病"
/// Stroke = "脑卒中"
/// DiabetesType2 = "糖尿病（Ⅱ型）"
/// EarlyCardiovascularDisease = "早发心血管疾病史"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FamilyHistoryEnum
{
    [Display(Name = "高血压")]
    Hypertension,
    [Display(Name = "冠心病")]
    CoronaryHeartDisease,
    [Display(Name = "脑卒中")]
    Stroke,
    [Display(Name = "糖尿病（Ⅱ型）")]
    DiabetesType2,
    [Display(Name = "早发心血管疾病史")]
    EarlyCardiovascularDisease
}


