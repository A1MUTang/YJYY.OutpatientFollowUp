using System.ComponentModel.DataAnnotations;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血压结果
    /// </summary>
    public enum BloodPressureResultEnum
    {
        /// <summary>
        /// 低血压
        /// </summary>
        /// <remarks>SBP小于90或DBP小于60</remarks>
        [Display(Name = "低血压",
            Description = "您本次血压偏低，请注意测量方法是否正确，切勿急骤起身站立，建议休息后复测您的血压，若血压持续偏低或伴不适症状，建议在家人协助下就医。")]
        LowBloodPressure,

        /// <summary>
        /// 使用降压药使用降糖药大于等于65岁血压达标
        /// </summary>
        /// <remarks>SBP小于150或DBP小于90</remarks>
        [Display(Name = "使用降压药使用降糖药大于等于65岁血压达标",
            Description = "您本次血压达标，望继续保持，建议至少了个月测量血压1次。坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureMetForOver65WithMedication,

        /// <summary>
        /// 使用降压药使用降糖药大于等于65岁血压不达标
        /// </summary>
        /// <remarks>SBP大于等于150或DBP大于等于90</remarks>
        [Display(Name = "使用降压药使用降糖药大于等于65岁血压不达标",
            Description = "您本次血压不达标，请请注意测量方法是否正确，休息后复测血压并及时就医调整治疗方案。建议您2~4周测量血压1次，坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureNotMetForOver65WithMedication,

        /// <summary>
        /// 使用降压药使用降糖药小于65岁血压达标
        /// </summary>
        /// <remarks>SBP小于140且DBP小于90</remarks>
        [Display(Name = "使用降压药使用降糖药小于65岁血压达标",
            Description = "您本次血压达标，望继续保持，建议至少了个月测量血压1次。坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureMetForUnder65WithMedication,

        /// <summary>
        /// 使用降压药使用降糖药小于65岁血压不达标
        /// </summary>
        /// <remarks>SBP大于等于140或DBP大于等于90</remarks>
        [Display(Name = "使用降压药使用降糖药小于65岁血压不达标",
            Description = "您本次血压不达标，请请注意测量方法是否正确，休息后复测血压并及时就医调整治疗方案。建议您2~4周测量血压1次，坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureNotMetForUnder65WithMedication,

        /// <summary>
        /// 使用降压药不使用降糖药大于等于65岁血压达标
        /// </summary>
        /// <remarks>SBP小于140且DBP小于90</remarks>
        [Display(Name = "使用降压药不使用降糖药大于等于65岁血压达标",
            Description = "您本次血压达标，望继续保持，建议至少了个月测量血压1次。坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureMetForOver65WithAntihypertensiveMedication,

        /// <summary>
        /// 使用降压药不使用降糖药大于等于65岁血压不达标
        /// </summary>
        /// <remarks>SBP大于等于140或DBP大于等于90</remarks>
        [Display(Name = "使用降压药不使用降糖药大于等于65岁血压不达标",
            Description = "您本次血压不达标，请请注意测量方法是否正确，休息后复测血压并及时就医调整治疗方案。建议您2~4周测量血压1次，坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureNotMetForOver65WithAntihypertensiveMedication,

        /// <summary>
        /// 使用降压药不使用降糖药小于65岁血压达标
        /// </summary>
        /// <remarks>SBP小于140且DBP小于90</remarks>
        [Display(Name = "使用降压药不使用降糖药小于65岁血压达标",
            Description = "您本次血压达标，望继续保持，建议至少了个月测量血压1次。坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureMetForUnder65WithAntihypertensiveMedication,

        /// <summary>
        /// 使用降压药不使用降糖药小于65岁血压不达标
        /// </summary>
        /// <remarks>SBP大于等于140或DBP大于等于90</remarks>
        [Display(Name = "使用降压药不使用降糖药小于65岁血压不达标",
            Description = "您本次血压不达标，请请注意测量方法是否正确，休息后复测血压并及时就医调整治疗方案。建议您2~4周测量血压1次，坚持家庭血压自测将有助于更好的管理您的健康。")]
        IsBloodPressureNotMetForUnder65WithAntihypertensiveMedication,

        /// <summary>
        /// 不使用降压药小于45岁血压达标
        /// </summary>
        /// <remarks>SBP小于120且DBP小于80</remarks>
        [Display(Name = "不使用降压药小于45岁血压达标",
            Description = "您本次血压正常，望继续保持。建议您每年测量血压1~2次")]
        IsBloodPressureMetForUnder45WithoutMedication,

        /// <summary>
        /// 不使用降压药大于45岁血压达标
        /// </summary>
        /// <remarks>SBP小于140且DBP小于90</remarks>
        [Display(Name = "不使用降压药大于45岁血压达标",
            Description = "您本次血压正常，望继续保持。建议您每3~6个月测量血压 1次，并接受医务人员的生活方式指导。")]
        IsBloodPressureMetForOver45WithoutMedication,

        /// <summary>
        /// 不使用降压药血压高于理想状态
        /// </summary>
        /// <remarks>SBP大于等于120或DBP大于等于80</remarks>
        [Display(Name = "不使用降压药血压高于理想状态",
            Description = "您本次血压高于理想水平，建议您每 3~6 个月测量血压 1次，并按受医务人员的生活方式指导。")]
        IsBloodPressureAboveIdealWithoutMedication,

        /// <summary>
        /// 不使用降压药血压偏高
        /// </summary>
        /// <remarks>SBP大于等于120或DBP大于等于80</remarks>
        [Display(Name = "不使用降压药血压偏高",
            Description = "您木次血压偏高，请注意测量方法是否正确，休息后复测血压。建议您及时就诊，遵循健康生活方式，包括：限制盐的摄入、均衡营养、控制体重、戒烟、限酒、适当运动、心理平衡。")]
        IsBloodPressureSlightlyHighWithoutMedication,

        /// <summary>
        /// 不使用降压药血压较高
        /// </summary>
        /// <remarks>SBP大于等于140或DBP大于等于90</remarks>
        [Display(Name = "不使用降压药血压较高",
            Description = "您本次血压较高，请注意测量方法是否正确，休息后复测血压。建议您及时就诊遵医嘱规律治疗，遵循健康生活方式，包括：限制盐的摄入、均衡营养、控制体重、戒烟、限酒、适当运动、心理平衡。")]
        IsBloodPressureModeratelyHighWithoutMedication,

        /// <summary>
        /// 不使用降压药血压很高
        /// </summary>
        /// <remarks>SBP大于等于160或DBP大于等于100</remarks>
        [Display(Name = "不使用降压药血压很高",
            Description = "您本次血压很高，请注意测量方法。建议复测，如您多次测量仍无明显改善，请尽快就医。")]
        IsBloodPressureVeryHighWithoutMedication
    }
}