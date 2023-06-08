namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class DoctorinfoDto : IValidatableObject
    {
        /// <summary>
        /// 医生id
        /// </summary>
        [Required(ErrorMessage = "医生id不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 医生头像
        /// </summary>
        [Required(ErrorMessage = "医生头像不能为空")]
        public string ImgPath { get; set; }

        /// <summary>
        /// 医生性别
        /// </summary>
        [Required(ErrorMessage = "医生性别不能为空")]
        public string Gender { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 是否需要修改密码
        /// </summary>
        /// <value></value>
        public bool IsPasswordChangeRequired { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}