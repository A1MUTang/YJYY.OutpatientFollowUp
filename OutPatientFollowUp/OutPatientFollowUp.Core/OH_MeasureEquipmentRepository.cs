using SqlSugar;

namespace OutPatientFollowUp.Core
{
    public class OH_MeasureEquipmentRepository : BaseRepository<OH_MeasureEquipment>, IOH_MeasureEquipmentRepository
    {
        public OH_MeasureEquipmentRepository(ISqlSugarClient context) : base(context)
        {
        }

    }
}