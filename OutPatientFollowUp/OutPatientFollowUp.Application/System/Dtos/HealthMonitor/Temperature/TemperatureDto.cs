using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Dto
{
    public class TemperatureDto
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string MacID { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// 体温结果
        /// </summary>
        public TemperatureResultEnum TemperatureResultCode { get; set; }

        /// <summary>
        /// 体温结果
        /// </summary>
        public string TemperatureResult { get; set; }
    }
}