using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core
{
    public enum BloodSugarResultEnum
    {
        /// <summary>
        /// 低血糖
        /// </summary>
        [Display(Name = "低血糖")]
        Low,

        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        Normal,

        /// <summary>
        /// 偏高
        /// </summary>
        [Display(Name = "偏高")]
        High,

        /// <summary>
        /// 很高
        /// </summary>
        [Display(Name = "很高")]
        VeryHigh,

    }
}