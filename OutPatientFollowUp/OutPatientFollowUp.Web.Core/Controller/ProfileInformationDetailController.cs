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
    /// <param name="archivesCode">基本档案信息</param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ProfileInformationDetailDto> GetAsync(string archivesCode)
    {
        throw new NotImplementedException();
        // return _profileInformationDetailAppService.GetAsync(basicProfileInformationId);
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
        throw new NotImplementedException();         
        // return _profileInformationDetailAppService.SaveAsync(basicProfileInformationId, input);
    }

}
