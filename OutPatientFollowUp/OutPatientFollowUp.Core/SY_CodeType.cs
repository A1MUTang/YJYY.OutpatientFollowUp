using System;
namespace OutPatientFollowUp.Core;
/// <summary>
/// 编码类型实体类
/// </summary>
[Serializable]
public partial class SY_CodeType
{

    /// <summary>
    /// 编码类型ID
    /// </summary>
    public int? SCT_ID { get; set; }

    /// <summary>
    /// 编码类型编码
    /// </summary>
    public string SCT_Code { get; set; }

    /// <summary>
    /// 编码类型名称
    /// </summary>
    public string SCT_Name { get; set; }

    /// <summary>
    /// 编码类型索引
    /// </summary>
    public int? SCT_Index { get; set; }

}
