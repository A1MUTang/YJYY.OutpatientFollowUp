using System.Text.RegularExpressions;

namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 创建基础档案信息
    /// </summary>
    public class CreateBasicProfileInformationDto : IValidatableObject
    {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 性别 false:女 true:男
        /// </summary>
        /// <value></value>
        public bool Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        /// <value></value>
        public string IDCardNumber { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 地址 (身份证上的地址)
        /// </summary>
        /// <value></value>
        public string Address { get; set; }

        /// <summary>
        /// 现住址
        /// </summary>
        /// <value></value>
        public string CurrentAddress { get; set; }

        /// <summary>
        /// 是否正在服用降压药 false:否 true:是
        /// </summary>
        /// <value></value>
        public bool IsTakingAntihypertensiveMeds { get; set; }

        /// <summary>
        /// 是否正在服用降糖药 false:否 true:是
        /// </summary>
        /// <value></value>
        public bool IsTakingAntidiabeticMeds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(IDCardNumber, @"^\d{17}(\d|X)$"))
            {
                yield return new ValidationResult("身份证号格式不正确", new[] { nameof(IDCardNumber) });
            }
            if (!Regex.IsMatch(PhoneNumber, @"^1[3456789]\d{9}$"))
            {
                yield return new ValidationResult("手机号格式不正确", new[] { nameof(PhoneNumber) });
            }
        }

    }

}