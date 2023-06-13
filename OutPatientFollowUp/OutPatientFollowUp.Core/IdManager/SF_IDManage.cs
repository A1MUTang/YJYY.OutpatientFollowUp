using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 身份证管理类
    /// </summary>
    public class SF_IDManage
    {
        /// <summary>
        /// 身份证ID
        /// </summary>
        public string SID_ID { get; set; }
        /// <summary>
        /// 身份证表格
        /// </summary>
        public string SID_Table { get; set; }
        /// <summary>
        /// 身份证编码
        /// </summary>
        public string SID_Code { get; set; }
        /// <summary>
        /// 身份证位数
        /// </summary>
        public int? SID_Bit { get; set; }
        /// <summary>
        /// 身份证最后日期
        /// </summary>
        public DateTime? SID_LastDate { get; set; }
        /// <summary>
        /// 身份证最后编号
        /// </summary>
        public int SID_LastNum { get; set; }
        /// <summary>
        /// 身份证备注
        /// </summary>
        public string SID_Remark { get; set; }
    }
}
