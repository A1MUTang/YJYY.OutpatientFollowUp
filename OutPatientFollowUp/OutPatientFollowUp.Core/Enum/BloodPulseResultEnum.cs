using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 脉搏结果
/// </summary>
public enum BloodPulseResultEnum
{
    /// <summary>
    /// 脉搏过慢
    /// </summary>
    [Display(Name = "脉搏过慢")]
    SlowPulse,

    /// <summary>
    /// 脉搏正常
    /// </summary>
    [Display(Name = "脉搏正常")]
    NormalPulse,

    /// <summary>
    /// 脉搏过快
   /// </summary>
    [Display(Name = "脉搏过快")]
    FastPulse

}