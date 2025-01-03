namespace OutPatientFollowUp.Application;

/// <summary>
/// 基础档案信息服务
/// </summary>
public interface IUserAppService : ITransient
{
    /// <summary>
    /// 登录 未填充token，请web端填充
    /// </summary>
    /// <param name="loginDto">入参</param>
    /// <returns></returns>
    Task<LoginOtput> LoginAsync(LoginInput loginDto);

#if DEBUG
    /// <summary>
    ///  发送修改密码验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<string> SendChangePwdVerificationCodeAsync(SendChangePwdVerificationCodeInput input);
#elif RELEASE
      /// <summary>
    ///  发送修改密码验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> SendChangePwdVerificationCodeAsync(SendChangePwdVerificationCodeInput input);
#endif



    /// <summary>
    /// 验证修改密码的验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<VerifyChangePwdVerificationCodeOutput> VerifyChangePwdVerificationCodeAsync(VerifyChangePwdVerificationCodeInput input);

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> ChangePwdAsync(ChangePwdInput input);

    /// <summary>
    /// 第一次登录修改密码
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<bool> FirstLoginChangePwdAsync(string userId, FirstLoginChangePwdInput input);

}