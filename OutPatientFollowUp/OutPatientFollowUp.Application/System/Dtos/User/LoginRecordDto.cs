namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class LoginRecordDto : IValidatableObject
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime { get; set; }

        /// <summary>
        /// 登录方式
        /// </summary>
        public string LoginMode { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        public string MacID { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>
        public string LoginStatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
