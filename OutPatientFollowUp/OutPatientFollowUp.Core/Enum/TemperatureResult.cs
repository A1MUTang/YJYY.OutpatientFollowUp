using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
    public enum TemperatureResult
    {
        [Display(Name = "低于正常")]
        BelowNormal,
        [Display(Name = "正常")]
        Normal,
        [Display(Name = "轻度异常")]
        MildAbnormality,
        [Display(Name = "严重异常")]
        SevereAbnormality
    }