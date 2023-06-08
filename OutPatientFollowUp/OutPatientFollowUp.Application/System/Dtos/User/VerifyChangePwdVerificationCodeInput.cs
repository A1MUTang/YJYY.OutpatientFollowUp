using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 校验修改密码验证码 
    /// </summary>
    public class VerifyChangePwdVerificationCodeInput :IValidatableObject
    {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        public string VerificationCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Regex.IsMatch(PhoneNumber,@"^1[3456789]\d{9}$")==false)
            {
                yield return new ValidationResult("手机号格式不正确",new[]{nameof(PhoneNumber)});
            }
            if(Regex.IsMatch(VerificationCode,@"^\d{6}$")==false)
            {
                yield return new ValidationResult("验证码格式不正确",new[]{nameof(VerificationCode)});
            }
        }
    }
}