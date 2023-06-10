using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OutPatientFollowUp.Application
{
    public class FirstLoginChangePwdInput :IValidatableObject
    {
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string PassWord { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(!Regex.IsMatch(PassWord,@"^[a-zA-Z0-9]{6,20}$"))
           {
               yield return new ValidationResult("密码格式不正确");
           }
        }
    }
}