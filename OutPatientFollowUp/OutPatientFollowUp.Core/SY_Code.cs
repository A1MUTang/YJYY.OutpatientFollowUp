using System;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 
/// </summary>
[Serializable]
public partial class SY_Code
{
    /// <summary>
    /// 编码ID
    /// </summary>
    public int? SYC_ID { get; set; }

    /// <summary>
    /// 编码类型ID
    /// </summary>
    public int? SCT_ID { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string SYC_Code { get; set; }

    /// <summary>
    /// 编码名称
    /// </summary>
    public string SYC_Name { get; set; }

    /// <summary>
    /// 编码排序
    /// </summary>
    public int? SYC_Index { get; set; }

    /// <summary>
    /// 编码链接
    /// </summary>
    public string SYC_Url { get; set; }

    /// <summary>
    /// 父级编码ID
    /// </summary>
    public int? SYC_ParentID { get; set; }
   

}
