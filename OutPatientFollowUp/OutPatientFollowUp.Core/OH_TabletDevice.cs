using System;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 平板设备信息类
    /// </summary>
    public class OH_TabletDevice
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        
        /// <summary>
        /// 平板SN号，一个平板可关联5个不同设备 血压、血糖、体温、血脂、血氧
        /// </summary>
        public string TabletSN { get; set; }
        
        /// <summary>
        /// 平板名称
        /// </summary>
        public string TabletName { get; set; }
        
        /// <summary>
        /// 平板系列
        /// </summary>
        public string TabletSeries { get; set; }
        
        /// <summary>
        /// sim卡号
        /// </summary>
        public string SIM { get; set; }
        
        /// <summary>
        /// sim卡充值时间
        /// </summary>
        public DateTime SimCZtime { get; set; }
        
        /// <summary>
        /// sim卡到期时间
        /// </summary>
        public DateTime SimDQtime { get; set; }
        
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime Productiontime { get; set; }
        
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        
        /// <summary>
        /// 入库人
        /// </summary>
        public string Warehouseman { get; set; }
        
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime WarehousingDate { get; set; }
        
        /// <summary>
        /// 设备位置
        /// </summary>
        public string MacPlace { get; set; }
        
        /// <summary>
        /// 数据上传类型 3 门诊；4上臂
        /// </summary>
        public int DataSources { get; set; }
        
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 管理机构名称
        /// </summary>
        public string ManageName { get; set; }
        
        /// <summary>
        /// 设备状态 1弃用，2有效
        /// </summary>
        public int State { get; set; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public OH_TabletDevice()
        {
            // 初始化 SimCZtime 和 SimDQtime 为默认值
            SimCZtime = DateTime.MinValue;
            SimDQtime = DateTime.MinValue;
        }
    }
}