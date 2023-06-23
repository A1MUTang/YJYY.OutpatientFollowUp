using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Core.HealthMonitor;

[ApiController]
[Route("api/[controller]")]
public class BloodSugarController : ControllerBase
{

    /// <summary>
    /// 创建血糖记录
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <param name="input">入参</param>
    /// <remarks>会创建血糖信息</remarks>
    /// <returns></returns>
    [HttpPost()]
    public async Task<BloodSugarDto> CreateAsync(string archivesCode, CreateOrUpdateBloodSugarDto input)
    {
        return new BloodSugarDto()
        {
        };
        //    return  await _bloodLipidAppService.CreateAsync(archivesCode, input);
    }

    /// <summary>
    /// 获取血糖
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <remarks>会获取最新当前血糖</remarks> 
    /// <returns></returns>
    [HttpGet()]
    public async Task<BloodSugarDto> GetAsync(string archivesCode)
    {
        return new BloodSugarDto()
        {
        };
    }
    // private readonly IBloodPressureAppService _bloodPressureAppService;
}
