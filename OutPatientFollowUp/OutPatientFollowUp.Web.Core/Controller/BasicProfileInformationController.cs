using System.Net;
using System;
using System.Threading.Tasks;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using Microsoft.AspNetCore.Authorization;

namespace OutPatientFollowUp.Web.Core.Controller;

[ApiController]
[Route("api/[controller]")]
[UnifyModel(typeof(CustomResponse<>))]
[Authorize] 
public class BasicProfileInformationController : ControllerBase
{
    private readonly IProfileInformationAppService _profileInformationAppService;
    public BasicProfileInformationController(IProfileInformationAppService profileInformationAppService)
    {
        _profileInformationAppService = profileInformationAppService;
    }

    /// <summary>
    /// 创建患者基本信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<BasicProfileInformationDto> CreateAsync(CreateBasicProfileInformationDto input)
    {
        return await _profileInformationAppService.CreateBasicProfileInformationAsync(input);
    }
    /// <summary>
    /// 获取患者基本信息
    /// </summary>
    /// <param name="IDCardNumber">身份证号</param>
    /// <remarks>身份证号仅支持18位字符串</remarks>
    /// <returns></returns>
    [HttpGet()]
    public async Task<BasicProfileInformationDto> GetAsync(string IDCardNumber)
    {
        return await _profileInformationAppService.GetBasicProfileInformationAsync(IDCardNumber);
    }
    /// <summary>
    /// 更新患者基本信息
    /// </summary>
    /// <param name="input">入参</param>
    /// <param name="archivesCode">建档案编号</param>
    /// <remarks>仅支持更改手机号，是否正在服用降压药，是否正在服用降糖药</remarks>
    /// <returns></returns>
    [HttpPut]
    public async Task<BasicProfileInformationDto> UpdateAsync(string archivesCode, UpdateBasicProfileInformationDto input)
    {
       return await _profileInformationAppService.UpdateBasicProfileInformationAsync(archivesCode, input);
    }

}