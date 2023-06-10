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

    }
}