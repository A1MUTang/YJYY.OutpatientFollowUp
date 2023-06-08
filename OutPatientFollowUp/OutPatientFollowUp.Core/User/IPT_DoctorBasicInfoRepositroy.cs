using Furion.DependencyInjection;

namespace OutPatientFollowUp.Core
{
    public interface IPT_DoctorBasicInfoRepositroy<User> : IBaseRepository<User> where User : class, new()
    {
      
    }
}