using System;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 视图
/// </summary>
[Serializable]
public partial class view_GetDicText
{
    /// <summary>
    /// 所属类别ID
    /// </summary>
    public string SYC_ID { get; set; }

    /// <summary>
    /// 所属类别编码
    /// </summary>
    public string SYC_Code { get; set; }

    /// <summary>
    /// 所属类别名称
    /// </summary>
    public string SYC_Name { get; set; }

    /// <summary>
    /// 子类编码
    /// </summary>
    public string SCT_Code { get; set; }

    /// <summary>
    /// 排序索引
    /// </summary>
    public int? SYC_Index { get; set; }

}

