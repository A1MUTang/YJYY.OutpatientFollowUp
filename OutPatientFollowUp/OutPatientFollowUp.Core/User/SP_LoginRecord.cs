using System;

namespace OutPatientFollowUp.Core;
public class SP_LoginRecord
{
    /// <summary>
    /// 登录记录ID
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Mac地址
    /// </summary>
    public string MacID { get; set; }

    /// <summary>
    /// 医生手机号
    /// </summary>
    public string DoctorPhone { get; set; }

    /// <summary>
    /// 登录状态
    /// </summary>
    public string LoginStatus { get; set; }

    /// <summary>
    /// 登录方式
    /// </summary>
    public string LoginMode { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime? LoginTime { get; set; }

    /// <summary>
    /// 医生ID
    /// </summary>
    public string DoctorID { get; set; }
}