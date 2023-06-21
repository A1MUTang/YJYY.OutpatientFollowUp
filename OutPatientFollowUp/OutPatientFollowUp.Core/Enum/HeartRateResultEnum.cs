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
        [Display(Name = "脉搏过慢",Description ="脉搏过慢")]
        Bradycardia,

        /// <summary>
        /// 脉搏正常
        /// </summary>
        [Display(Name = "脉搏正常",Description ="脉搏正常")]
        Normal,

        /// <summary>
        /// 脉搏过快
        /// </summary>
        [Display(Name = "脉搏过快",Description ="脉搏过快")]
        Tachycardia,
    }
}