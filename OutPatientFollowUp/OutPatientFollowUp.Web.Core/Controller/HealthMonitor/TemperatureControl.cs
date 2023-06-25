using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Dto;

namespace OutPatientFollowUp.Core.HealthMonitor;

/// <summary>
/// 体温
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TemperatureControl : ControllerBase
{
    private readonly IBodyTemperatureAppService _temperatureAppService;

    public TemperatureControl(IBodyTemperatureAppService temperatureAppService)
    {
        _temperatureAppService = temperatureAppService;
    }
    /// <summary>
    /// 录入体温
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<TemperatureDto> CreateAsync(string archivesCode, CreateOrUpdateTemperatureDto input)
    {
      return await _temperatureAppService.CreateAsync(archivesCode, input);       
    }

    /// <summary>
    /// 获取体温
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<TemperatureDto> GetAsync(string archivesCode)
    {
        return await _temperatureAppService.GetByArchivesCodeAsync(archivesCode);
    }
}

