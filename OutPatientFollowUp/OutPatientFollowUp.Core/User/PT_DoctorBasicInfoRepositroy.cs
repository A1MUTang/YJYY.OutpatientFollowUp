using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class PT_DoctorBasicInfoRepositroy : BaseRepository<PT_DoctorBasicInfo>, IPT_DoctorBasicInfoRepositroy
{
    public PT_DoctorBasicInfoRepositroy(ISqlSugarClient context) : base(context)
    {

    }

    public async Task<bool> ChangePwd(string id, string pwd)
    {
        var doctor = await Context.Queryable<PT_DoctorBasicInfo>().FirstAsync(x => x.Doctor_ID == id);
        doctor.Doctor_Pwd = pwd;
        doctor.IsPerfectPwd = 1;
        var result = await Context.Updateable(doctor).WhereColumns(it => new { it.Doctor_ID}).ExecuteCommandAsync();
        return result > 0 ? true : false;
    }

}