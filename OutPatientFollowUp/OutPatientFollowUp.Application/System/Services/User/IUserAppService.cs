namespace OutPatientFollowUp.Application;

/// <summary>
/// 基础档案信息服务
/// </summary>
public interface IUserAppService : ITransient
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="loginDto">入参</param>
    /// <returns></returns>
    Task<DoctorinfoDto> Login(LoginInput loginDto);

    /// <summary>
    ///  发送修改密码验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SendChangePwdVerificationCodeOutput> SendChangePwdVerificationCode(SendChangePwdVerificationCodeInput input);

    /// <summary>
    /// 验证修改密码的验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<VerifyChangePwdVerificationCodeOutput> VerifyChangePwdVerificationCode(VerifyChangePwdVerificationCodeInput input);

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> ChangePwd(ChangePwdInput input);

}