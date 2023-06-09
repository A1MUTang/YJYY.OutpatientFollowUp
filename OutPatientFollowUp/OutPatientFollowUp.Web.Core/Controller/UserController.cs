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
    public UserController()
    {
    }

    /// <summary>
    /// 登录    
    /// </summary>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<LoginOtput> Login(LoginInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 发送修改密码验证码
    /// </summary>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost("SendChangePwdVerificationCodeInput")]
    public async Task<bool> SendChangePwdVerificationCode(SendChangePwdVerificationCodeInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 验证修改密码验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("VerifyChangePwdVerificationCode")]
    public async Task<VerifyChangePwdVerificationCodeOutput>  VerifyChangePwdVerificationCode(VerifyChangePwdVerificationCodeInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("ChangePwd")]
    public async Task<bool> ChangePwd(ChangePwdInput input)
    {
        throw new NotImplementedException();
    }

}