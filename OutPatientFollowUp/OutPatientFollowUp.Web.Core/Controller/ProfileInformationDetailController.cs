using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 基本档案信息
/// </summary>
// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileInformationDetailController : ControllerBase
{
    // private readonly IProfileInformationDetailAppService _profileInformationDetailAppService;
    // public ProfileInformationDetailController(IProfileInformationDetailAppService profileInformationDetailAppService)
    // {
    //     _profileInformationDetailAppService = profileInformationDetailAppService;
    // }

    /// <summary>
    /// 获取档案信息
    /// </summary>
    /// <param name="basicProfileInformationId">基本档案信息</param>
    /// <remarks>当前响应结果为基础档案信息+最近一条档案详情</remarks>
    /// <returns></returns>
    [HttpGet("{basicProfileInformationId}")]
    public async Task<ProfileInformationDetailDto> GetAsync(System.Guid basicProfileInformationId)
    {
        throw new NotImplementedException();
        // return _profileInformationDetailAppService.GetAsync(basicProfileInformationId);
    }

    /// <summary>
    /// 保存档案信息
    /// </summary>
    /// <param name="basicProfileInformationId">基本档案信息</param>
    /// <param name="input">入参</param>
    /// <remarks>当前逻辑为修改基础档案信息+添加一条档案详情数据</remarks>
    /// <returns></returns>
    [HttpPost("{basicProfileInformationId}")]
    public async Task<ProfileInformationDetailDto> SaveAsync(Guid basicProfileInformationId, CreateOrUpdateProfileInformationDetailDto input)
    {
        throw new NotImplementedException();         
        // return _profileInformationDetailAppService.SaveAsync(basicProfileInformationId, input);
    }

}
