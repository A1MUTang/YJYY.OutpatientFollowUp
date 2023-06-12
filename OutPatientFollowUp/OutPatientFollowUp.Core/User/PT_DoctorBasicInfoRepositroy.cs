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

    public async Task<string> GetDoctorManageName(string doctorId)
    {
        //获取医生对应的manageName Doctor_WorkUnits字段 与 PT_OrgnameForParent表 OrgName 匹配然后获取ManageName
        
        var doctor = await Context.Queryable<PT_DoctorBasicInfo>().FirstAsync(x => x.Doctor_ID == doctorId);
        var manageUnit = await Context.Queryable<PT_OrgnameForParent>().FirstAsync(x => x.OrgName == doctor.Doctor_WorkUnits);
        return manageUnit.ManageName;
    }

}