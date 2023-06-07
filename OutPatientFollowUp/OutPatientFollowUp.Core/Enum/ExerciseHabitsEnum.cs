using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 体育运动习惯枚举
/// <remarks>
/// Unknown = "不详"
/// NeverExercise = "从不运动"
/// AerobicExercise = "有氧运动"
/// IntenseExercise = "剧烈运动"
/// </remarks>
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExerciseHabitsEnum
{
    [Display(Name = "不详")]
    Unknown,
    [Display(Name = "从不运动")]
    NeverExercise,
    [Display(Name = "有氧运动")]
    AerobicExercise,
    [Display(Name = "剧烈运动")]
    IntenseExercise
}

