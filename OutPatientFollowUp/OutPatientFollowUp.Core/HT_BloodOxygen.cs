using System;

namespace OutPatientFollowUp.Core;
public class HT_BloodOxygen
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
    /// 测量日期
    /// </summary>
    public DateTime MeasureDate { get; set; } = DateTime.Now;

    /// <summary>
    /// 体温
    /// </summary>
    /// <value></value>
    public decimal BloodOxygen { get; set; }

    /// <summary>
    /// 数据来源
    /// </summary>
    public string DataSource { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remarks { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public DateTime CreateDate { get; set; } = DateTime.Now;

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
    /// 是否删除
    /// </summary>
    public int IsDelete { get; set; } = 0;

    /// <summary>
    /// 服务ID
    /// </summary>
    public string SvcId { get; set; }

}