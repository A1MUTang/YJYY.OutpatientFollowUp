using Furion.DependencyInjection;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public interface IBaseRepository<T> : ITransient, ISimpleClient<T> where T : class, new()
{

}