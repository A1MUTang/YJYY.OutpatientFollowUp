using System;

namespace Hypertension.Models
{
    public class PT_EquipMentVersionManage
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string EqpNo { get; set; }
        
        /// <summary>
        /// APK类型
        /// </summary>
        public string ApkType { get; set; }
        
        /// <summary>
        /// 父级名称
        /// </summary>
        public string ParentName { get; set; }
        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        
        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionNumber { get; set; }
        
        /// <summary>
        /// APK下载地址
        /// </summary>
        public string ApkUrl { get; set; }
        
        /// <summary>
        /// 发布类型
        /// </summary>
        public int PublishType { get; set; }
        
        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectTime { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperatorPerson { get; set; }
        
        /// <summary>
        /// 是否撤销
        /// </summary>
        public int IsRevoke { get; set; }
        
        /// <summary>
        /// 撤销时间
        /// </summary>
        public DateTime? RevokeTime { get; set; }
        
        /// <summary>
        /// 撤销人
        /// </summary>
        public string RevokePerson { get; set; }
        
        /// <summary>
        /// 描述信息
        /// </summary>
        public string DescribeInfo { get; set; }
    }
}