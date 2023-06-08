using System;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 
/// </summary>
[Serializable]
public partial class SY_Code
{

    /// <summary>
    /// 
    /// </summary>
    public int? SYC_ID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? SCT_ID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string SYC_Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string SYC_Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? SYC_Index { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string SYC_Url { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? SYC_ParentID { get; set; }

}
