using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 既往病史枚举
/// <remarks>
/// None = "未发现"
/// Hypertension = "高血压"
/// CerebrovascularDisease = "脑血管病"
/// HeartDisease = "心脏疾病"
/// PeripheralVascularDisease = "外周血管病"
/// RetinalDisease = "视网膜疾病"
/// DiabetesType2 = "糖尿病（Ⅱ型）"
/// KidneyDisease = "肾病"
/// PCOS = "多囊卵巢综合征（PCOS）"
/// GestationalDiabetes = "妊娠糖尿病史"
/// AcanthosisNigricans = "黑棘皮症"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PastMedicalHistoryEnum
{
    [Display(Name = "未发现")]
    None,
    [Display(Name = "高血压")]
    Hypertension,
    [Display(Name = "脑血管病")]
    CerebrovascularDisease,
    [Display(Name = "心脏疾病")]
    HeartDisease,
    [Display(Name = "外周血管病")]
    PeripheralVascularDisease,
    [Display(Name = "视网膜疾病")]
    RetinalDisease,
    [Display(Name = "糖尿病（Ⅱ型）")]
    DiabetesType2,
    [Display(Name = "肾病")]
    KidneyDisease,
    [Display(Name = "多囊卵巢综合征（PCOS）")]
    PCOS,
    [Display(Name = "妊娠糖尿病史")]
    GestationalDiabetes,
    [Display(Name = "黑棘皮症")]
    AcanthosisNigricans
}


