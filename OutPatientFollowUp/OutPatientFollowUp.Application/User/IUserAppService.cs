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
    Task<DoctorinfoDto> Login(LoginDto loginDto);


}