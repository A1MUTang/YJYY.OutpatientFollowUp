using System;

namespace OutPatientFollowUp.Core;
[Serializable]
public class PT_DoctorBasicInfo
{
    /// <summary>
    /// 医生姓名拼音缩写
    /// </summary>
    public string Doctor_NameAcronym { get; set; }

    /// <summary>
    /// 医生在线状态
    /// </summary>
    public string Doctor_OnlineStatus { get; set; }

    /// <summary>
    /// 医生用户积分
    /// </summary>
    public int? Doctor_Userintegral { get; set; }

    /// <summary>
    /// 医生签名
    /// </summary>
    public int? Doctor_Sign { get; set; }

    /// <summary>
    /// 医生通过
    /// </summary>
    public int? Doctor_Passe { get; set; }

    /// <summary>
    /// 医生ID
    /// </summary>
    public string Doctor_ID { get; set; }

    /// <summary>
    /// 医生电话
    /// </summary>
    public string Doctor_Phone { get; set; }

    /// <summary>
    /// 医生用户名
    /// </summary>
    public string Doctor_UserName { get; set; }

    /// <summary>
    /// 医生密码
    /// </summary>
    public string Doctor_Pwd { get; set; }

    /// <summary>
    /// 医生性别
    /// </summary>
    public string Doctor_Gender { get; set; }

    /// <summary>
    /// 医生身份证号
    /// </summary>
    public string Doctor_ICard { get; set; }

    /// <summary>
    /// 旧电话
    /// </summary>
    public string OldPhone { get; set; }

    /// <summary>
    /// 医生类型
    /// </summary>
    public string Doctor_type { get; set; }

    /// <summary>
    /// PI得分
    /// </summary>
    public string PI_Score { get; set; }

    /// <summary>
    /// 医生创建时间
    /// </summary>
    public string Doctor_CreateTime { get; set; }

    /// <summary>
    /// 医生创建人
    /// </summary>
    public string Doctor_CreatePople { get; set; }

    /// <summary>
    /// 医生状态
    /// </summary>
    public string Doctor_State { get; set; }

    /// <summary>
    /// 医生原因
    /// </summary>
    public string Docto_Reason { get; set; }

    /// <summary>
    /// 医生通过创建时间
    /// </summary>
    public string Doctor_PassCreaTime { get; set; }

    /// <summary>
    /// 医生通过人
    /// </summary>
    public string Doctor_PassPeple { get; set; }
}
    