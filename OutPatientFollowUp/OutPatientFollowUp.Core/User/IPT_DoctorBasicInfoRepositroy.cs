using System.Threading.Tasks;
using Furion.DependencyInjection;

namespace OutPatientFollowUp.Core
{
    public interface IPT_DoctorBasicInfoRepositroy : IBaseRepository<PT_DoctorBasicInfo>
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Task<bool> ChangePwd(string id, string pwd);

        /// <summary>
        /// 获取医生对应的manageName Doctor_WorkUnits字段 与 PT_OrgnameForParent表 OrgName 匹配然后获取ManageName
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public  Task<string> GetDoctorManageName(string doctorId);

        /// <summary>
        /// 获取医生对应的Doctor_WorkUnits字段  
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
         public Task<string> GetDoctorWorkUnits(string doctorId);

    }
}