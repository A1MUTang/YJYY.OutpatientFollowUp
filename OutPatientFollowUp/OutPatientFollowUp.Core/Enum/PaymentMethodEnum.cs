using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 医疗费用支付方式枚举
/// <remarks>
/// SelfPayment = "自费"
/// HealthInsurance = "医保"
/// CommercialInsurance = "商业保险"
/// PublicFunding = "公费"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethodEnum
{
    /// <summary>
    /// 自费
    /// </summary>
    [Display(Name = "自费")]
    SelfPayment,
    [Display(Name = "医保")]
    HealthInsurance,
    [Display(Name = "商业保险")]
    CommercialInsurance,
    [Display(Name = "公费")]
    PublicFunding
}



