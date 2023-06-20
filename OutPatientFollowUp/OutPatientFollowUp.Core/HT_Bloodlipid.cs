using System;
namespace OutPatientFollowUp.Core;

public class HT_Bloodlipid
{

    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    public string ID { get; set; }
    /// <summary>
    /// 建档号
    /// </summary>
    /// <value></value>
    public string ArchivesCode { get; set; }
    /// <summary>
    /// 设备号
    /// </summary>
    /// <value></value>
    public string MacID { get; set; }
    /// <summary>
    /// 设备名称
    /// </summary>
    /// <value></value>
    public string Manufacture { get; set; }
    /// <summary>
    /// 测量时间
    /// </summary>
    /// <value></value>
    public DateTime MeasureDate { get; set; }
    /// <summary>
    /// 总胆固醇
    /// </summary>
    /// <value></value>
    public decimal TC { get; set; }
    /// <summary>
    /// 高密度脂蛋白胆固醇
    /// </summary>
    /// <value></value>
    public decimal HDL { get; set; }
    /// <summary>
    /// 低密度脂蛋白胆固醇
    /// </summary>
    /// <value></value>
    public decimal LDL { get; set; }
    /// <summary>
    /// 甘油三酯
    /// </summary>
    /// <value></value>
    public decimal TG { get; set; }
    /// <summary>
    /// 数据来源
    /// </summary>
    /// <value></value>
    public string DataSource { get; set; } = "4";
    public string Remarks { get; set; } ="设备导入";
    public DateTime CreateDate { get; set; } = DateTime.Now;
    /// <summary>
    /// 姓名
    /// </summary>
    /// <value></value>
    public string UserName { get; set; }
    /// <summary>
    /// 性别
    /// </summary>
    /// <value></value>
    public string Gender { get; set; }
    /// <summary>
    /// 身份证号
    /// </summary>
    /// <value></value>
    public string ICard { get; set; }
    /// <summary>
    /// 患者的管理机构
    /// </summary>
    /// <value></value>
    public string CreateArchivesUnit { get; set; }
    /// <summary>
    /// 是否删除 0 未删除 1 已删除
    /// </summary>
    /// <value></value>
    public bool IsDelete { get; set; }
    /// <summary>
    /// 服务ID
    /// </summary>
    /// <value></value>
    public string SvcId { get; set; }
    /// <summary>
    /// 手机号
    /// </summary>
    /// <value></value>
    public string DocPhone { get; set; }
    /// <summary>
    /// 是否更新
    /// </summary>
    /// <value></value>
    public bool IsUpdate { get; set; }
    /// <summary>
    /// 是否是高血压药
    /// </summary>
    /// <value></value>
    public bool IsHdrug { get; set; }
    /// <summary>
    /// 是否是降脂药
    /// </summary>
    /// <value></value>
    public bool IsSdrug { get; set; }
}