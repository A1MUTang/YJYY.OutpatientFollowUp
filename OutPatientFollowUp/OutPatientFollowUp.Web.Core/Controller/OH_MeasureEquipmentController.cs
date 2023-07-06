using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 基本档案信息
/// </summary>
// [Authorize]
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class OH_MeasureEquipmentController : ControllerBase
{
    private readonly IPT_MeasureEquipmentAppService _oh_MeasureEquipmentAppService;

    public OH_MeasureEquipmentController(IPT_MeasureEquipmentAppService oh_MeasureEquipmentAppService)
    {
        _oh_MeasureEquipmentAppService = oh_MeasureEquipmentAppService;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost()]
    public async Task<DeviceDto> GetUpdateInfo(GetUpdateInfoDto getUpdateInfoDto)
    {
        return await _oh_MeasureEquipmentAppService.GetUpdateInfo(getUpdateInfoDto.eqpNo, getUpdateInfoDto.versionNumber, "YWSF-SM-TF701", getUpdateInfoDto.parentName, getUpdateInfoDto.unitName);
    }


    


}

public class GetUpdateInfoDto
{
    /// <summary>
    /// 设备编号
    /// </summary>
    /// <value></value>
    public string eqpNo { get; set; }
    /// <summary>
    /// 版本号
    /// </summary>
    /// <value></value>
    public string versionNumber { get; set; }
    /// <summary>
    /// 父级名称
    /// </summary>
    /// <value></value>
    public string parentName { get; set; } = "全部";
    /// <summary>
    /// 单位名称
    /// </summary>
    /// <value></value>
    public string unitName { get; set; } = "全部";

}
