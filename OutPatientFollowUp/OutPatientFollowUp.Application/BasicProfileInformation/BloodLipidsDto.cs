namespace OutPatientFollowUp.Application.HealthMonitor;

    /// <summary>
    /// 血脂
    /// </summary>
    public class BloodLipidsDto 
    {
        /// <summary>
        /// 基础档案信息主键
        /// </summary>
        /// <value></value>
        public Guid BasicProfileInformationId { get; set; }
        /// <summary>
        /// 健康基础信息
        /// </summary>
        /// <remarks>测量结果中的抬头</remarks>
        /// <value></value>
        public HealthMonitorBaseDto HealthMonitorBaseDto { get; set; }
        /// <summary>
        /// 总胆固醇
        /// </summary>
        /// <remarks>单位：mmol/L</remarks>
        /// <value></value>
        public double TotalCholesterol { get; set; }
        /// <summary>
        /// 甘油三酯
        /// </summary>
        /// <remarks>单位：mmol/L</remarks>
        /// <value></value>
        public double Triglycerides { get; set; }
        /// <summary>
        /// 高密度脂蛋白胆固醇
        /// </summary>
        /// <remarks>单位：mmol/L</remarks>
        /// <value></value>
        public double HDLCholesterol { get; set; }
        /// <summary>
        /// 低密度脂蛋白胆固醇
        /// </summary>
        /// <remarks>单位：mmol/L</remarks>
        /// <value></value>
        public double LDLCholesterol { get; set; }

        /// <summary>
        /// 血脂结果
        /// </summary>
        /// <value></value>
        public string BloodLipidsResult { get; set; }

        /// <summary>
        /// 健康建议
        /// </summary>
        /// <value></value>
        public string HealthAdvice { get; set; }

        /// <summary>
        /// 高密度脂蛋白胆固醇 (HDL-C)水平
        /// </summary>
        public string HDLCholesterolLevel { get; set; }


    }
