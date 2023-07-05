using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 基本档案信息
/// </summary>
// [Authorize]
[ApiController]
[Route("api/[controller]")]
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
    /// <param name="eqpNo"></param>
    /// <param name="versionNumber"></param>
    /// <param name="apkType"></param>
    /// <param name="parentName"></param>
    /// <param name="unitName"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<DeviceDto> GetUpdateInfo(string eqpNo, string versionNumber, string apkType = "YWSF-SM-TF701", string parentName = "全部", string unitName = "全部")
    {
        return await _oh_MeasureEquipmentAppService.GetUpdateInfo(eqpNo, versionNumber, apkType, parentName, unitName);
    }


}
