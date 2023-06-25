using System;
namespace OutPatientFollowUp.Core;

public class HT_Temperature
{
    /// <summary>
    /// 主键，自增长的整数类型。
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 基础档案信息主键，字符串类型。
    /// </summary>
    public string ArchivesCode { get; set; }

    /// <summary>
    /// 体温，decimal 类型。
    /// </summary>
    public decimal Temperature { get; set; }

    /// <summary>
    /// 创建时间，DateTime 类型。
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 创建档案单位，字符串类型。
    /// </summary>
    public string CreateArchivesUnit { get; set; }

    /// <summary>
    /// 管理组织，字符串类型。
    /// </summary>
    public string ManageOrganization { get; set; }
}