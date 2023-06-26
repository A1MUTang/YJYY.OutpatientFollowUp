using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 问卷问题类型
/// </summary>
/// <remarks>单选、多选、填空</remarks>
/// </summary>
public enum SurveyQuestionTypeEnum
{
    [Display(Name = "单选")]
    SingleChoice,
    [Display(Name = "多选")]
    MultipleChoice,
    [Display(Name = "填空")]
    FillInBlank
}
