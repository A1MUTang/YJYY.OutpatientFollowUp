using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;

namespace OutPatientFollowUp.Core.HealthMonitor;

[ApiController]
[Route("api/[controller]")]
public class BloodPressureController : ControllerBase
{
    private readonly IBloodPressureAppService _bloodPressureAppService;
    public BloodPressureController(IBloodPressureAppService bloodPressureAppService)
    {
        _bloodPressureAppService = bloodPressureAppService;
    }

    /// <summary>
    /// 创建血压记录
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <param name="input">入参</param>
    /// <remarks>会创建血压信息</remarks>
    /// <returns></returns>
    [HttpPost()]
    public async Task<BloodPressureDto> CreateAsync(string archivesCode, CreateOrUpdateBloodPressureDto input)
    {
        return await _bloodPressureAppService.CreateAsync(archivesCode, input);
    }

    /// <summary>
    /// 获取血压
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <remarks>会获取最新当前血脂压</remarks> 
    /// <returns></returns>
    [HttpGet()]
    public async Task<BloodPressureDto> GetAsync(string archivesCode)
    {
        return await _bloodPressureAppService.GetAsync(archivesCode);
    }
}