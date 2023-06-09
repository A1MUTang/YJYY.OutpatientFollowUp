using System.Threading.Tasks;
using Furion.DependencyInjection;

namespace OutPatientFollowUp.Core
{
    public interface IPT_DoctorBasicInfoRepositroy : IBaseRepository<PT_DoctorBasicInfo>
    {
        public Task<bool> ChangePwd(string id, string pwd);

    }
}