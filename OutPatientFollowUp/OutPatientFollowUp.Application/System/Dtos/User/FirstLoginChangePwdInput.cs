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
           if(!Regex.IsMatch(PassWord,@"^(?=(.*\d.*[\p{P}\p{S}\p{C}]|[\p{P}\p{S}\p{C}].*\d))(?=(.*[a-zA-Z].*[\p{P}\p{S}\p{C}]|[\p{P}\p{S}\p{C}].*[a-zA-Z]))[\p{L}\p{N}\p{P}\p{S}\p{C}]{6,20}$"))
           {
               yield return new ValidationResult("密码格式不正确");
           }
        }
    }
}