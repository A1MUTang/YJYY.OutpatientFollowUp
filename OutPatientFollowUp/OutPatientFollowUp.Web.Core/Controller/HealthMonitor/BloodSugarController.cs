using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Core.HealthMonitor;

[ApiController]
[Route("api/[controller]")]
public class BloodSugarController : ControllerBase
{
    private readonly IBloodSugarAppService _bloodSugarAppService;

    public BloodSugarController(IBloodSugarAppService bloodSugarAppService)
    {
        _bloodSugarAppService = bloodSugarAppService;
    }

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
        return await _bloodSugarAppService.CreateAsync(archivesCode, input);
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
        return await _bloodSugarAppService.GetAsync(archivesCode);
    }
}
