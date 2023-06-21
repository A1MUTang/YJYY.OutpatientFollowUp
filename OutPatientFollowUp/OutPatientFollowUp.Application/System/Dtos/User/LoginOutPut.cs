namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class LoginOtput
    {
        /// <summary>
        /// id
        /// </summary>
        [Required(ErrorMessage = "医生id不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Required(ErrorMessage = "医生头像不能为空")]
        public string ImgPath { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "医生性别不能为空")]
        public string Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        /// <value></value>
        public string IDCardNumber { get; set; }

        /// <summary>
        /// 是否需要修改密码
        /// </summary>
        /// <value></value>
        public bool IsPasswordChangeRequired { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>

        public string PhoneNumber { get; set; }

        /// <summary>
        /// 令牌 24小时
        /// </summary>
        /// <value></value>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新token 7天
        /// </summary>
        /// <value></value>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 所属机构名称
        /// </summary>
        /// <value></value>
        public string ManageName { get; set; }

    }
}