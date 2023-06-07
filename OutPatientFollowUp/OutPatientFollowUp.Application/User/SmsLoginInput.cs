using System.Text.RegularExpressions;
namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 基础档案信息服务
    /// </summary>
    public class SmsLoginInput : IValidatableObject
    {
        /// <summary>
        /// 设备号
        /// </summary>
        /// <value></value>
        public string MacId { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        public string DoctorPhone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(MacId))
            {
                yield return new ValidationResult("设备号不能为空", new[] { nameof(MacId) });
            }
            if (Regex.IsMatch(DoctorPhone, @"^1[3456789]\d{9}$") == false)
            {
                yield return new ValidationResult("医生手机号格式不正确", new[] { nameof(DoctorPhone) });
            }

        }
    }
}