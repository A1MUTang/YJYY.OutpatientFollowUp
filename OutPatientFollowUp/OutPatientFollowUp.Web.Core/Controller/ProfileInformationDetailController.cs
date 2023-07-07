using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 基本档案信息
/// </summary>
// [Authorize]
[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class ProfileInformationDetailController : ControllerBase
{
    private readonly IProfileInformationAppService _profileInformationAppService;
    public ProfileInformationDetailController(IProfileInformationAppService profileInformationAppService)
    {
        _profileInformationAppService = profileInformationAppService;
    }
    // private readonly IProfileInformationDetailAppService _profileInformationDetailAppService;
    // public ProfileInformationDetailController(IProfileInformationDetailAppService profileInformationDetailAppService)
    // {
    //     _profileInformationDetailAppService = profileInformationDetailAppService;
    // }

    /// <summary>
    /// 获取档案信息
    /// </summary>
    /// <param name="archivesCode">基本档案信息</param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ProfileInformationDetailDto> GetAsync(string archivesCode)
    {
        return await _profileInformationAppService.GetProfileInformationDetailAsync(archivesCode);
    }

    /// <summary>
    /// 保存档案信息
    /// </summary>
    /// <param name="archivesCode">基本档案信息</param>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<ProfileInformationDetailDto> SaveAsync(string archivesCode, CreateOrUpdateProfileInformationDetailDto input)
    {
        
        return await _profileInformationAppService.CreateOrUpdateProfileInformationDetailAsync(archivesCode, input);
    }

}
