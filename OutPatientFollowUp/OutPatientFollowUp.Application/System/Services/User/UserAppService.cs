using Microsoft.Extensions.Caching.Memory;
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

    /// <summary>
    /// 修改密码验证码缓存Key
    /// </summary>
    public const string ChangePwdCodeKeyPrefix = "ChangePwdCodeKey_";

    /// <summary>
    /// 修改密码验证码过期时间
    /// <remarks>单位：分钟</remarks>
    /// </summary>
    public const int ChangePwdCodeExpiration = 1;



    private readonly IPT_DoctorBasicInfoRepositroy _doctorBasicInfoRepositroy;

    private readonly ILoginRecordRepository _loginRecordRepository;

    private readonly SMShandle _smsHandle;

    private readonly IMemoryCache _memoryCache;

    public UserAppService(IPT_DoctorBasicInfoRepositroy doctorBasicInfoRepositroy, ILoginRecordRepository loginRecordRepository, SMShandle smsHandle, IMemoryCache memoryCache)
    {
        _doctorBasicInfoRepositroy = doctorBasicInfoRepositroy;
        _loginRecordRepository = loginRecordRepository;
        _smsHandle = smsHandle;
        _memoryCache = memoryCache;
    }


    public async Task<bool> ChangePwdAsync(ChangePwdInput input)
    {

        //判断两次密码是否一致
        if (input.NewPwd != input.ConfirmNewPwd)
        {
            Oops.Oh("两次密码不一致");
        }
        //获取原有的用户信息

        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_ID == input.UserId);
        //判断用户是否存在
        if (existUser == null)
        {
            Oops.Oh("用户不存在");
        }
        //判断验证码是否过期
        await VerifyChangePwdVerificationCodeAsync(new VerifyChangePwdVerificationCodeInput
        {
            PhoneNumber = existUser.Doctor_Phone,
            VerificationCode = input.VerificationCode
        });
        //将完善密码字段改为1，已完善
        existUser.IsPerfectPwd = 1;
        //将用户输入的密码加密
        var pwd = DEncrypt.Md5(input.NewPwd);
        //修改密码
        //保存
        var result = await _doctorBasicInfoRepositroy.ChangePwd(existUser.Doctor_ID, pwd);

        return result;
    }

    public async Task<LoginOtput> LoginAsync(LoginInput loginDto)
    {
        //TODO:需要添加设备ID交验select count(*) from (select ParentName from PT_EQPDistribution where {0}=@{0} ) t1inner join PT_OrgnameForParent t2 on t1.ParentName=t2.ParentNamewhere OrgName='{1}
        //TODO：和张行确认设备绑定的相关内容
        //获取用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_Phone == loginDto.DoctorPhone);
        //判断用户是否存在
        if (existUser == null)
        {
            throw Oops.Oh("用户不存在");
        }
        //判断密码是否正确
        if (existUser.IsPerfectPwd.GetValueOrDefault() == 1)
        {
            // 加密 新的方式
            if (!DEncrypt.Md5(loginDto.DoctorPass.Trim()).ToLower().Equals(existUser.Doctor_Pwd.ToLower()))
            {
                throw Oops.Oh("用户名密码错误");
            }
        }
        else
        {
            // 加密 老的方式
            if (!Md5Helper.Encryption(loginDto.DoctorPass.Trim()).Equals(existUser.Doctor_Pwd))
            {
                throw Oops.Oh("用户名密码错误");
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
        //生成访问Token
        var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "UserId", existUser.Doctor_ID },  // 存储Id
                { "Account",    existUser.Doctor_UserName }, // 存储用户名
                { "ManageName", await _doctorBasicInfoRepositroy.GetDoctorManageName(existUser.Doctor_ID) }, // 存储管理单位
                { "WorkUnits", await _doctorBasicInfoRepositroy.GetDoctorWorkUnits(existUser.Doctor_ID)}  //GetDoctorWorkUnits
            });
        // 生成刷新Token
        var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, refreshTokenExpiration);
        // 设置响应报文头

        //返回用户信息
        return new LoginOtput()
        {
            ID = existUser.Doctor_ID,
            ImgPath = existUser.Doctor_ImgPath,
            UserName = existUser.Doctor_UserName,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            IsPasswordChangeRequired = existUser.IsPerfectPwd.GetValueOrDefault() == 0 ? true : false,
            Gender = existUser.Doctor_Gender,
            IDCardNumber = existUser.Doctor_ICard
        };
    }

#if DEBUG
    public async Task<string> SendChangePwdVerificationCodeAsync(SendChangePwdVerificationCodeInput input)
    {

        //获取用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_Phone == input.DoctorPhone);
        //判断用户是否存在
        if (existUser == null)
        {
            throw Oops.Oh("用户不存在");
        }
        //生成验证码（6位数）
        var code = SMShandle.GetRandomCode();
        string messageContent = @"您的验证码为：" + code + "，有效时间1分钟，切勿将验证码泄露于他人。";
        //判断缓存中有没有对应的验证码，如果有，提示已发送验证码，如果没有，发送验证码
        if (_memoryCache.TryGetValue(input.DoctorPhone + ChangePwdCodeKeyPrefix, out string cacheCode))
        {
            throw Oops.Oh("已发送验证码，请注意查收");
        }
        //将验证码存入缓存中
        _memoryCache.Set(input.DoctorPhone + ChangePwdCodeKeyPrefix, code, TimeSpan.FromMinutes(ChangePwdCodeExpiration));
        //发送验证码通过短信的形式
        _smsHandle.APPSendSM(input.DoctorPhone, messageContent); //TODO 短信发送，记录日志内容
        return messageContent;
    }
#elif RELEASE
   public async Task<bool> SendChangePwdVerificationCodeAsync(SendChangePwdVerificationCodeInput input)
    {

        //获取用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_Phone == input.DoctorPhone);
        //判断用户是否存在
        if (existUser == null)
        {
            throw Oops.Oh("用户不存在");
        }
        //生成验证码（6位数）
        var code = SMShandle.GetRandomCode();
        string messageContent = @"您的验证码为：" + code + "，有效时间1分钟，切勿将验证码泄露于他人。";
        //判断缓存中有没有对应的验证码，如果有，提示已发送验证码，如果没有，发送验证码
        if (_memoryCache.TryGetValue(input.DoctorPhone + ChangePwdCodeKeyPrefix, out string cacheCode))
        {
            throw Oops.Oh("已发送验证码，请注意查收");
        }
        //将验证码存入缓存中
        _memoryCache.Set(input.DoctorPhone + ChangePwdCodeKeyPrefix, code, TimeSpan.FromMinutes(ChangePwdCodeExpiration));
        //发送验证码通过短信的形式
        _smsHandle.SendSM(input.DoctorPhone, messageContent);
        return true;
    }
#endif






    public async Task<VerifyChangePwdVerificationCodeOutput> VerifyChangePwdVerificationCodeAsync(VerifyChangePwdVerificationCodeInput input)
    {

        //获取用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_Phone == input.PhoneNumber);
        //判断用户是否存在
        if (existUser == null)
        {
            throw Oops.Oh("用户不存在");
        }
        //验证验证码
        if (!_memoryCache.TryGetValue(input.PhoneNumber + ChangePwdCodeKeyPrefix, out string cacheCode))
        {
            throw Oops.Oh("验证码已过期");
        }
        if (cacheCode != input.VerificationCode)
        {
            throw Oops.Oh("验证码错误");
        }
        return new VerifyChangePwdVerificationCodeOutput
        {
            UserId = existUser.Doctor_ID
        };
    }

    public async Task<bool> FirstLoginChangePwdAsync(string userId, FirstLoginChangePwdInput input)
    {
        //获取原有的用户信息
        var existUser = await _doctorBasicInfoRepositroy.GetSingleAsync(x => x.Doctor_ID == userId);
        //判断用户是否存在
        if (existUser == null)
        {
            throw Oops.Oh("用户不存在");
        }
        //将用户输入的密码加密
        var pwd = DEncrypt.Md5(input.PassWord);
        //保存
        var result = await _doctorBasicInfoRepositroy.ChangePwd(existUser.Doctor_ID, pwd);
        return result;


    }
}