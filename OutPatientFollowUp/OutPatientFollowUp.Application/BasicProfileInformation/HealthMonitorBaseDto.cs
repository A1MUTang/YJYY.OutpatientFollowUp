namespace OutPatientFollowUp.Application.HealthMonitor
{
    /// <summary>
    /// 健康基础信息
    /// </summary>
    public class HealthMonitorBaseDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        ///性别：男、女
        /// </summary>
        /// <value></value>
        public string Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        /// <value></value>

        public string IDCardNumber { get; set; }
    }
}