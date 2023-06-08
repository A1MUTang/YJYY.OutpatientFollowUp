using System;
namespace OutPatientFollowUp.Core;
/// <summary>
/// 
/// </summary>
[Serializable]
public partial class PT_OrgnameForParent
{


    /// <summary>
    /// CD05
    /// </summary>
    public decimal? CD05 { get; set; }

    /// <summary>
    /// CDother
    /// </summary>
    public decimal? CDother { get; set; }

    /// <summary>
    /// Age4
    /// </summary>
    public decimal? Age4 { get; set; }

    /// <summary>
    /// Age5
    /// </summary>
    public decimal? Age5 { get; set; }

    /// <summary>
    /// AllCount
    /// </summary>
    public decimal? AllCount { get; set; }

    /// <summary>
    /// Man
    /// </summary>
    public decimal? Man { get; set; }

    /// <summary>
    /// Women
    /// </summary>
    public decimal? Women { get; set; }

    /// <summary>
    /// Age1
    /// </summary>
    public decimal? Age1 { get; set; }

    /// <summary>
    /// Age2
    /// </summary>
    public decimal? Age2 { get; set; }

    /// <summary>
    /// Age3
    /// </summary>
    public decimal? Age3 { get; set; }

    /// <summary>
    /// 机构ID
    /// </summary>
    public string OrgID { get; set; }

    /// <summary>
    /// 机构名称
    /// </summary>
    public string OrgName { get; set; }

    /// <summary>
    /// 父机构名称
    /// </summary>
    public string ParentName { get; set; }

    /// <summary>
    /// 管理机构名称
    /// </summary>
    public string ManageName { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    public string Provice { get; set; }

    /// <summary>
    /// 中心位置
    /// </summary>
    public string CenterPosition { get; set; }

    /// <summary>
    /// 左下位置
    /// </summary>
    public string LowerLeftPosition { get; set; }

    /// <summary>
    /// 右上位置
    /// </summary>
    public string UpperRightPosition { get; set; }

    /// <summary>
    /// 圆圈颜色
    /// </summary>
    public string CircleColor { get; set; }


}
