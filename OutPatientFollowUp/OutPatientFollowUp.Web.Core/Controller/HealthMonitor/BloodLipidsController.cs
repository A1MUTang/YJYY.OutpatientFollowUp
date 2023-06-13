using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Core.HealthMonitor;

/// <summary>
/// 血脂
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BloodLipidsController : ControllerBase
{
    // private readonly IBloodLipidsAppService _bloodLipidsAppService;


    // public BloodLipidsController(IBloodLipidsAppService bloodLipidsAppService)
    // {
    //     _bloodLipidsAppService = bloodLipidsAppService;
    // }

    /// <summary>
    /// 创建血脂记录
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <param name="input">入参</param>
    /// <remarks>会创建血脂信息</remarks>
    /// <returns></returns>
    [HttpPost()]
    public async Task<BloodLipidsDto> CreateAsync(string archivesCode, CreateOrUpdateBloodLipidsDto input)
    {
        throw new NotImplementedException();
        // return await _bloodLipidsAppService.CreateAsync(archivesCode, input);
    }

    /// <summary>
    /// 获取血脂
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键</param>
    /// <remarks>会获取最新当前血脂和基础档案部分信息</remarks> 
    /// <returns></returns>
    [HttpGet()]
    public async Task<BloodLipidsDto> GetAsync(string archivesCode)
    {
        throw new NotImplementedException();
        // return await _bloodLipidsAppService.GetAsync(archivesCode);
    }
}