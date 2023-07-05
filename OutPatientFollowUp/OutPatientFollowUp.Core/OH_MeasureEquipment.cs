using System;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 设备信息类
    /// </summary>
    public class OH_MeasureEquipment
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        
        /// <summary>
        /// 设备型号
        /// </summary>
        public string DeviceModel { get; set; }
        
        /// <summary>
        /// 蓝牙名称
        /// </summary>
        public string BluetoothName { get; set; }
        
        /// <summary>
        /// 蓝牙MAC地址
        /// </summary>
        public string BluetoothMAC { get; set; }
        
        /// <summary>
        /// 设备/服务ID
        /// </summary>
        public string DeviceID { get; set; }
        
        /// <summary>
        /// 系列/特性ID
        /// </summary>
        public string SeriesID { get; set; }
        
        /// <summary>
        /// 设备种类 血压、血糖、体温、血脂、血氧
        /// </summary>
        public string DeviceClass { get; set; }
        
        /// <summary>
        /// 设备厂商
        /// </summary>
        public string Manufacturer { get; set; }
        
        /// <summary>
        /// 平板SN号，一个平板可关联5个不同设备 血压、血糖、体温、血脂、血氧
        /// </summary>
        public string TabletSN { get; set; }
        
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

    }
}