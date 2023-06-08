using System.Text.RegularExpressions;
namespace OutPatientFollowUp.Web.Core.Controller
{
    public class ChangePwdInput : IValidatableObject
    {
        
        /// <summary>
        /// 新密码
        /// </summary>
        /// <remarks>密码必须包含数字和字母，长度在 6 到 16 个字符之间</remarks>
        /// <value></value>
        public string NewPwd { get; set; }

        /// <summary>
        /// 确认新密码
        /// </summary>
        /// <remarks>密码必须包含数字和字母，长度在 6 到 16 个字符之间</remarks>
        /// <value></value>
        public string ConfirmNewPwd { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            /// <summary>
            /// 新密码 
            /// </summary>
            /// <param name="="></param>
            /// <remarks>密码必须包含数字和字母，长度在 6 到 16 个字符之间</remarks>
            /// <returns></returns>
            if (Regex.IsMatch(NewPwd, @"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,16}$") == false)
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