using SqlSugar;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 登录记录
/// </summary>
public class LoginRecordRepository : BaseRepository<SP_LoginRecord>, ILoginRecordRepository
{
    public LoginRecordRepository(ISqlSugarClient context) : base(context)
    {
    }

}