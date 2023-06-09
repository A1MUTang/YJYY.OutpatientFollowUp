using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;


public class UserAppService : IUserAppService
{
    /// <summary>
    /// 访问Token过期时间
    /// <remarks>单位：分钟</remarks>
    /// </summary>
    public const int accessTokenExpiration = 60 * 24;

    /// <summary>
    /// 刷新Token过期时间
    /// <remarks>单位：分钟</remarks>
    /// </summary>
    public const int refreshTokenExpiration = 60 * 24 * 7;

    private readonly IPT_DoctorBasicInfoRepositroy _doctorBasicInfoRepositroy;

    private readonly ILoginRecordRepository _loginRecordRepository;

    private readonly SMShandle _smsHandle = new SMShandle();

    public UserAppService(IPT_DoctorBasicInfoRepositroy doctorBasicInfoRepositroy, ILoginRecordRepository loginRecordRepository)
    {
        _doctorBasicInfoRepositroy = doctorBasicInfoRepositroy;
        _loginRecordRepository = loginRecordRepository;
    }


    public async Task<bool> ChangePwdAsync(ChangePwdInput input)
    {
        //判断两次密码是否一致
        if (input.NewPwd != input.ConfirmNewPwd)
        {
            Oops.Oh("两次密码不一致");
        }
        //获取原有的用户信息

        var existUser = _doctorBasicInfoRepositroy.GetSingle(x => x.Doctor_ID == input.UserId);
        //判断用户是否存在
        if (existUser == null)
        {
            Oops.Oh("用户不存在");
        }
        //将完善密码字段改为1，已完善
        existUser.IsPerfectPwd = 1;
        //将用户输入的密码加密
        var pwd = Md5Helper.Encryption(input.NewPwd);
        //修改密码
        existUser.Doctor_Pwd = pwd;
        //保存
        var result = await _doctorBasicInfoRepositroy.UpdateAsync(existUser);

        return result;
    }

    public async Task<DoctorinfoDto> LoginAsync(LoginInput loginDto)
    {
        //TODO:登录
        //获取用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_Phone == loginDto.DoctorPhone);
        //判断用户是否存在
        if (existUser == null)
        {
            Oops.Oh("用户不存在");
        }
        //判断密码是否正确
        if (existUser.IsPerfectPwd.GetValueOrDefault() == 1)
        {
            // 加密 老的方式
            if (!DEncrypt.Md5(loginDto.DoctorPass.Trim()).ToLower().Equals(existUser.Doctor_Pwd))
            {
                Oops.Oh("用户名密码错误");
            }
        }
        else
        {
            // 加密 新的方式
            if (!Md5Helper.Encryption(loginDto.DoctorPass.Trim()).Equals(existUser.Doctor_Pwd))
            {
                Oops.Oh("用户名密码错误");
            }
        }
        //添加登录记录
        await _loginRecordRepository.InsertAsync(new SP_LoginRecord
        {
            LoginStatus = "登录",
            ID = Guid.NewGuid().ToString("N"),
            LoginMode = "手机号+密码",
            DoctorID = existUser.Doctor_ID,
            DoctorPhone = loginDto.DoctorPhone,
            MacID = loginDto.MacId,
        });
        //返回用户信息
        return existUser.Adapt<DoctorinfoDto>();
    }

    public Task<SendChangePwdVerificationCodeOutput> SendChangePwdVerificationCodeAsync(SendChangePwdVerificationCodeInput input)
    {
        //TODO:发送修改密码验证码

        //获取用户信息
        var existUser = _doctorBasicInfoRepositroy.GetSingle(x => x.Doctor_Phone == input.DoctorPhone);
        //判断用户是否存在
        if (existUser == null)
        {
            Oops.Oh("用户不存在");
        }
        //生成验证码（6位数）
        //发送验证码通过短信的形式
        throw new NotImplementedException();
    }

    public Task<VerifyChangePwdVerificationCodeOutput> VerifyChangePwdVerificationCodeAsync(VerifyChangePwdVerificationCodeInput input)
    {
        //TODO:验证修改密码验证码
        //获取用户信息
        //判断用户是否存在
        //验证验证码
        throw new NotImplementedException();
    }
}