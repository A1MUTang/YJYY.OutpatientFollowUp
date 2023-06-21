using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 脉搏结果枚举
    /// </summary>
    public enum HeartRateResultEnum
    {
        /// <summary>
        /// 脉搏过慢
        /// </summary>
        /// <remarks>脉搏小于60</remarks>
        [Display(Name = "脉搏过慢",Description ="脉搏过慢")]
        Bradycardia,

        /// <summary>
        /// 脉搏正常
        /// </summary>
        /// <remarks>脉搏60-100</remarks>
        [Display(Name = "脉搏正常",Description ="脉搏正常")]
        Normal,

        /// <summary>
        /// 脉搏过快
        /// </summary>
        /// <remarks>脉搏大于100</remarks>
        [Display(Name = "脉搏过快",Description ="脉搏过快")]
        Tachycardia,
    }
}