using System;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血压临时表
    /// </summary>
    public class HT_BlutdruckTemp
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 档案编号
        /// </summary>
        public string ArchivesCode { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public string MacID { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        public string Manufacture { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string MacType { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 测量日期
        /// </summary>
        public DateTime MeasureDate { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        public int SBP { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        public int DBP { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        public int MaiBo { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataSources { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 是否已上传
        /// </summary>
        public int IsUploaded { get; set; }

        /// <summary>
        /// 服务ID
        /// </summary>
        public string SvcId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string ICard { get; set; }

        /// <summary>
        /// 创建档案单位
        /// </summary>
        public string CreateArchivesUnit { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string HospitalizationNumber { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int HospitalizationCount { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VisitNumber { get; set; }
        /// <summary>
        /// 是否更新
        /// </summary>
        public string IsUpdate { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PersonPhone { get; set; }
        /// <summary>
        /// 设备位置
        /// </summary>
        public string MacPlace { get; set; }
        /// <summary>
        /// 父母姓名
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 是否使用降压药
        /// </summary>
        public int IsHdrug { get; set; }
        /// <summary>
        /// 是否使用降糖药
        /// </summary>
        public int IsSdrug { get; set; }
        /// <summary>
        /// 是否符合高血压标准
        /// </summary>
        public string IsGxyStandard { get; set; }
        /// <summary>
        /// 患者类型
        /// </summary>
        public int PatientType { get; set; }
        /// <summary>
        /// 计划ID
        /// </summary>
        public int PlanID { get; set; }
        /// <summary>
        /// 签约医生
        /// </summary>
        public string SignDoctor { get; set; }
        /// <summary>
        /// 是否上传至大数据中心
        /// </summary>
        public string IsDBCenter { get; set; }
    }
}