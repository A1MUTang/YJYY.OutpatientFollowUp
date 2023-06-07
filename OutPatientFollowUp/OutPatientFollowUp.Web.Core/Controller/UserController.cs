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
    public async Task<LoginDto> Login(LoginDto input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 短信登录
    /// </summary>
    /// <param name="input">入参</param>
    /// <returns></returns>
    [HttpPost("SmsLogin")]
    public async Task<SmsLoginOutput> SmsLogin(SmsLoginInput input)
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