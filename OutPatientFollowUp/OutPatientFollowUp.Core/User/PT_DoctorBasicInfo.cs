using System;

namespace OutPatientFollowUp.Core;
[Serializable]
public class PT_DoctorBasicInfo
{
    public string Doctor_NameAcronym { get; set; }
    public string Doctor_OnlineStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int? Doctor_Userintegral { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? Doctor_Sign { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? Doctor_Passe { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_ID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Phone { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_UserName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Pwd { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Gender { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_ICard { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string OldPhone { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PI_Score { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_CreateTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_CreatePople { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_State { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Docto_Reason { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_PassCreaTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_PassPeple { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Address { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_ZipCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_CumulativeTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_AvailableTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_PersonalProfile { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_UserLevel { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_WorkUnits { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Department { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Position { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Title { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_Number { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Doctor_ImgPath { get; set; }

    /// <summary>
    /// 新旧密码格式
    /// </summary>
    /// <remarks>1为新密码</remarks>
    /// <value></value>
    public int? IsPerfectPwd { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string IsDel { get; set; }
}
