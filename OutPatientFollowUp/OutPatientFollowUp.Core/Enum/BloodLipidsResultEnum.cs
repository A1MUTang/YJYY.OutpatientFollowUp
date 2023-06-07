using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 血脂结果
/// </summary>
public enum BloodLipidsResultEnum
{
    [Display(Name = "理想水平", Description = "您的结果目前处于理想水平，建议您保持良好生活方式，定期复查。")]
    Ideal, // 理想水平
    [Display(Name = "合适水平", Description = "您的结果目前处于合适水平，建议您保持良好生活方式，定期复查。")]
    Suitable, // 合适水平
    [Display(Name = "边缘升高",Description ="您当前检测结果【{0}】处于“边缘升高”阶段，建议您及时就医，指导生活方式或进一步检查、持续观察，祝您生活愉快。")]
    BorderlineHigh, // 边缘升高
    [Display(Name = "升高",Description ="您当前检测结果【{0}】处于“异常升高”阶段，建议您及时就医，进一步检查或制定干预方案，定期复检，祝您生活愉快。")]
    High, // 升高
    [Display(Name = "异常")]
    Abnormal // 异常
}