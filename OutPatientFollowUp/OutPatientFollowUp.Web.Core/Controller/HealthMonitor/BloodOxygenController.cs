using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Core.HealthMonitor;

/// <summary>
/// 血氧
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class BloodOxygenController : ControllerBase
{
    private readonly IBloodOxygenAppService _bloodOxygenAppService;

    public BloodOxygenController(IBloodOxygenAppService bloodOxygenAppService)
    {
        _bloodOxygenAppService = bloodOxygenAppService;
    }

    /// <summary>
    /// 录入血氧
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<BloodOxygenDto> CreateAsync(string archivesCode, CreateOrUpdateBloodOxygenDto input)
    {
        return await _bloodOxygenAppService.CreateAsync(archivesCode, input);
    }

    /// <summary>
    /// 获取血氧
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <returns></returns>
    [HttpGet()]
    public Task<BloodOxygenDto> GetAsync(string archivesCode)
    {
        return _bloodOxygenAppService.GetByArchivesCode(archivesCode);
    }
}