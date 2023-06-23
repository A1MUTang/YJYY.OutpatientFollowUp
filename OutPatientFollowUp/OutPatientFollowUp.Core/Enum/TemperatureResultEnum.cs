using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 体温结果枚举
    /// </summary>
    public enum TemperatureResultEnum
    {
        /// <summary>
        /// 低于正常
        /// </summary>
        [Display(Name = "低于正常", Description = "低于正常")]
        Low,

        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常", Description = "正常")]
        Normal,

        /// <summary>
        /// 轻度异常
        /// </summary>
        [Display(Name = "轻度异常", Description = "轻度异常")]
        MildAbnormal,

        /// <summary>
        /// 严重异常
        /// </summary>
        [Display(Name = "严重异常", Description = "严重异常")]
        SevereAbnormal,
    }
}