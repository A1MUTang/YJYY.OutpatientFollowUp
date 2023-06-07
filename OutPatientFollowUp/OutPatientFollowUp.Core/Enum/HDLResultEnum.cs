using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 总胆固醇结果 
/// </summary>
public enum HDLResultEnum
{
    [Display(Name = "正常")]
    Normal, // 正常
    [Display(Name = "降低",Description ="您当前检测结果【高密度脂蛋白(HDL-C)】低于“合适水平”，建议您及时就医，进一步检查或制定干预方案，定期复检，祝您生活愉快。")]
    Low // 降低
}