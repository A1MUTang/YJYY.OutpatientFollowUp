namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class LoginInput : IValidatableObject
    {
        /// <summary>
        /// 医生手机号
        /// </summary>
        [Required(ErrorMessage = "医生手机号不能为空")]
        public string DoctorPhone { get; set; }

        /// <summary>
        /// 医生凭证 密码/验证码
        /// </summary>
        [Required(ErrorMessage = "医生凭证不能为空")]
        public string DoctorPass { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [Required(ErrorMessage = "设备号不能为空")]
        public string MacId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}