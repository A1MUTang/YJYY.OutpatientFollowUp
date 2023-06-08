using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Core.HealthMonitor;

/// <summary>
/// 血氧
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class BloodOxygenController : ControllerBase
{
    // private readonly IBloodOxygenAppService _bloodOxygenAppService;

    // public BloodOxygenController(IBloodOxygenAppService bloodOxygenAppService)
    // {
    //     _bloodOxygenAppService = bloodOxygenAppService;
    // }

    /// <summary>
    /// 录入血氧
    /// </summary>
    /// <param name="basicProfileInformationId">基本档案信息Id</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("{basicProfileInformationId}")]
    public Task<BloodOxygenDto> CreateAsync(string basicProfileInformationId, CreateOrUpdateBloodOxygenDto input)
    {
        throw new NotImplementedException();
        // return _bloodOxygenAppService.CreateAsync(basicProfileInformationId, input);
    }

    /// <summary>
    /// 获取血氧
    /// </summary>
    /// <param name="basicProfileInformationId">基本档案信息Id</param>
    /// <returns></returns>
    [HttpGet("{basicProfileInformationId}")]
    public Task<BloodOxygenDto> GetAsync(string basicProfileInformationId)
    {
        throw new NotImplementedException();
        // return _bloodOxygenAppService.GetAsync(basicProfileInformationId);
    }
}