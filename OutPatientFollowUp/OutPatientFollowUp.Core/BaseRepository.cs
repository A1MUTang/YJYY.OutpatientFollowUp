using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class BaseRepository<T> : SimpleClient<T> where T : class, new()
{
    public BaseRepository(ISqlSugarClient context) : base(context)
    {
    }
}