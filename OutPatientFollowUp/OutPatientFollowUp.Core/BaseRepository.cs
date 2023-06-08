using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class BaseRepository<T>
{
    internal readonly ISqlSugarClient _db;
    public BaseRepository(ISqlSugarClient db)
    {
        _db = db;
    }


}