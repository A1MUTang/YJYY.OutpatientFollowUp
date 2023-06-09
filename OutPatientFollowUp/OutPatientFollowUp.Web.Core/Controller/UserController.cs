using System;
using System.Threading.Tasks;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;

namespace OutPatientFollowUp.Web.Core.Controller;

[ApiController]
[Route("api/[controller]")]
[UnifyModel(typeof(CustomResponse<>))]
public class UserController : ControllerBase
{

    private readonly IUserAppService _userAppService;
    public UserController( IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    /// <summary>
    /// 登录    
    /// </summary>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<LoginOtput> Login(LoginInput input)
    {
        return await _userAppService.LoginAsync(input);
    }

    /// <summary>
    /// 发送修改密码验证码
    /// </summary>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost("SendChangePwdVerificationCodeInput")]
    public async Task<bool> SendChangePwdVerificationCode(SendChangePwdVerificationCodeInput input)
    {
        return await _userAppService.SendChangePwdVerificationCodeAsync(input);
    }

    /// <summary>
    /// 验证修改密码验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("VerifyChangePwdVerificationCode")]
    public async Task<VerifyChangePwdVerificationCodeOutput>  VerifyChangePwdVerificationCode(VerifyChangePwdVerificationCodeInput input)
    {
        return await _userAppService.VerifyChangePwdVerificationCodeAsync(input);
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("ChangePwd")]
    public async Task<bool> ChangePwd(ChangePwdInput input)
    {
        return await _userAppService.ChangePwdAsync(input);
    }

}