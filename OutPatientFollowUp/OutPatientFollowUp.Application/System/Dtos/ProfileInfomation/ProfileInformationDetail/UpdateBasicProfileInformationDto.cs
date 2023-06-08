using System.Text.RegularExpressions;

namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 更新基础档案信息
    /// </summary>
    public class UpdateBasicProfileInformationDto :IValidatableObject
    {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        [Required, StringLength(11)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 是否正在服用降压药
        /// </summary>
        /// <value></value>
        [Required]
        public bool IsTakingAntihypertensiveMeds { get; set; }

        /// <summary>
        /// 是否正在服用降糖药
        /// </summary>
        /// <value></value>
        [Required]
        public bool IsTakingAntidiabeticMeds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(PhoneNumber, @"^1[3456789]\d{9}$"))
            {
                yield return new ValidationResult("手机号格式不正确", new[] { nameof(PhoneNumber) });
            }
        }
    }
}