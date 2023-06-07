using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

    /// <summary>
    /// 睡眠习惯枚举
    /// <remarks>
    /// Unknown = "不详"
    /// EarlySleep = "早睡"
    /// Normal = "正常"
    /// LateSleep = "晚睡"
    /// Insomnia = "失眠"
    /// </remarks>
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SleepHabitEnum
    {
        [Display(Name = "不详")]
        Unknown,
        [Display(Name = "早睡")]
        EarlySleep,
        [Display(Name = "正常")]
        Normal,
        [Display(Name = "晚睡")]
        LateSleep,
        [Display(Name = "失眠")]
        Insomnia
    }
