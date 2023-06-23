using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    // private readonly IBloodOxygenAppService _bloodOxygenAppService;

    // public BloodOxygenController(IBloodOxygenAppService bloodOxygenAppService)
    // {
    //     _bloodOxygenAppService = bloodOxygenAppService;
    // }

    /// <summary>
    /// 录入体温
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost()]
    public Task<TemperatureDto> CreateAsync(string archivesCode, CreateOrUpdateTemperature input)
    {
        throw new NotImplementedException();
        // return _bloodOxygenAppService.CreateAsync(archivesCode, input);
    }

    /// <summary>
    /// 获取体温
    /// </summary>
    /// <param name="archivesCode">基本档案信息Id</param>
    /// <returns></returns>
    [HttpGet()]
    public Task<TemperatureDto> GetAsync(string archivesCode)
    {
        throw new NotImplementedException();
        // return _bloodOxygenAppService.GetAsync(archivesCode);
    }
}

