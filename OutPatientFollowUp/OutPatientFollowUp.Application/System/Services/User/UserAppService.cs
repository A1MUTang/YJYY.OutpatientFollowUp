namespace OutPatientFollowUp.Application;


public class UserAppService : IUserAppService
{
    /// <summary>
    /// 访问Token过期时间
    /// <remarks>单位：分钟</remarks>
    /// </summary>
    public const int accessTokenExpiration = 60*24;

    /// <summary>
    /// 刷新Token过期时间
    /// <remarks>单位：分钟</remarks>
    /// </summary>
    public const int refreshTokenExpiration = 60*24*7;


    public Task<bool> ChangePwd(ChangePwdInput input)
    {
        //TODO:修改密码
        //获取原有的用户信息
        //判断旧密码是否正确
        //修改密码
        throw new NotImplementedException();
    }

    public async Task<DoctorinfoDto> Login(LoginInput loginDto)
    {
        //TODO:登录
        //获取用户信息
        //判断用户是否存在
        //判断密码是否正确
        //生成Token
        //返回用户信息
        throw new NotImplementedException();
    }

    public Task<SendChangePwdVerificationCodeOutput> SendChangePwdVerificationCode(SendChangePwdVerificationCodeInput input)
    {
        //TODO:发送修改密码验证码
        //获取用户信息
        //判断用户是否存在
        //生成验证码（6位数）
        //发送验证码通过短信的形式
        throw new NotImplementedException();
    }

    public Task<VerifyChangePwdVerificationCodeOutput> VerifyChangePwdVerificationCode(VerifyChangePwdVerificationCodeInput input)
    {
        //TODO:验证修改密码验证码
        //获取用户信息
        //判断用户是否存在
        //验证验证码
        throw new NotImplementedException();
    }
}