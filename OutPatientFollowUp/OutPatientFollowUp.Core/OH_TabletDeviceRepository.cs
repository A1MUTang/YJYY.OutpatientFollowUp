using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core
{
    public class OH_TabletDeviceRepository : BaseRepository<OH_TabletDevice>, IOH_TabletDeviceRepository
    {
        public OH_TabletDeviceRepository(ISqlSugarClient context) : base(context)
        {
        }

    }
}