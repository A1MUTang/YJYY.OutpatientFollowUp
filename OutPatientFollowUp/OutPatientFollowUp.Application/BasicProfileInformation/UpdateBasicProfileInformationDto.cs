namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 更新基础档案信息
    /// </summary>
    public class UpdateBasicProfileInformationDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <value></value>
        [Required, StringLength(11)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 是否正在服用降压药
        /// </summary>
        /// <value></value>
        [Required]
        public bool IsTakingAntihypertensiveMeds { get; set; }

        /// <summary>
        /// 是否正在服用降糖药
        /// </summary>
        /// <value></value>
        [Required]
        public bool IsTakingAntidiabeticMeds { get; set; }

    }
}