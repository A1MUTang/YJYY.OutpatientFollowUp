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

        public string CreateArchivesUnit { get; set; }
        public string HospitalizationNumber { get; set; }
        public int HospitalizationCount { get; set; }
        public string VisitNumber { get; set; }
        public int IsUpdate { get; set; }
        public string PersonPhone { get; set; }
        public string MacPlace { get; set; }
        public string ParentName { get; set; }
        public int IsHdrug { get; set; }
        public int IsSdrug { get; set; }
        public int IsGxyStandard { get; set; }
        public int PatientType { get; set; }
        public int PlanID { get; set; }
        public string SignDoctor { get; set; }
        public int IsDBCenter { get; set; }
    }
}