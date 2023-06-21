using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血压结果枚举
    /// </summary>
    public enum BloodPressureResultEnum
    {

        /// <summary>
        /// 低血压
        /// </summary>
        [Display(Name = "低血压",Description ="低血压")]
        Low,

        /// <summary>
        /// 理想血压
        /// </summary>
        [Display(Name = "理想",Description ="理想血压")]
        Ideal,

        /// <summary>
        /// 正常血压
        /// </summary>
        [Display(Name = "正常",Description ="正常血压")]
        Normal,

        /// <summary>
        /// 轻度高血压
        /// </summary>
        [Display(Name = "轻度",Description ="轻度高血压")]
        Mild,

        /// <summary>
        /// 中度高血压
        /// </summary>
        [Display(Name = "中度",Description ="中度高血压")]
        Moderate,

        /// <summary>
        /// 重度高血压
        /// </summary>
        [Display(Name = "重度",Description ="重度高血压")]
        Severe,

    }
}