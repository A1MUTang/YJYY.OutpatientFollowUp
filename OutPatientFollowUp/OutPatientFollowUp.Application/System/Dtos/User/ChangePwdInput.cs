using System.Text.RegularExpressions;
namespace OutPatientFollowUp.Application
{
    public class ChangePwdInput : IValidatableObject
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value></value>
        public string UserId { get; set; }

        /// <summary>
        /// 新密码 
        /// </summary>
        /// <remarks>密码必须包含数字和大小写字母符号，长度在 6 到 16 个字符之间</remarks>
        /// <returns></returns>
        public string NewPwd { get; set; }

        /// <summary>
        /// 新密码 
        /// </summary>
        /// <param name=""></param>
        /// <remarks>密码必须包含数字和大小写字母符号，长度在 6 到 16 个字符之间</remarks>
        /// <returns></returns>
        public string ConfirmNewPwd { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        public string VerificationCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!Regex.IsMatch(NewPwd, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[a-zA-Z0-9!@#$%^&*()_+]{8,16}$") == false)
            { //密码格式不正确
                yield return new ValidationResult("密码格式不正确", new[] { nameof(NewPwd) });
            }
            if (NewPwd != ConfirmNewPwd)
            {
                yield return new ValidationResult("两次输入的密码不一致", new[] { nameof(ConfirmNewPwd) });
            }


        }
    }
}