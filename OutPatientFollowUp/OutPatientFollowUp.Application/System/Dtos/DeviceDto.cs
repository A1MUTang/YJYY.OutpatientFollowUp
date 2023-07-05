using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

/// <summary>
///  App更新控制，设备信息类    
/// </summary>
public class DeviceDto
{
    /// <summary>
    /// 下载地址
    /// </summary>
    /// <value></value>
    public string ApkUrl { get; set; }

    /// <summary>
    /// 是否强制更新
    /// </summary>
    /// <value></value>
    public bool IsForceUpdate { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    /// <value></value>
    public List<OH_MeasureEquipment> Devices { get; set; }

}


