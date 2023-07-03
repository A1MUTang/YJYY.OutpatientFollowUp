using SqlSugar;

namespace OutPatientFollowUp.Core;

public class PT_EquipMentVersionManageRepository : BaseRepository<PT_EquipMentVersionManage>, IPT_EquipMentVersionManageRepository
{
    public PT_EquipMentVersionManageRepository(ISqlSugarClient context) : base(context)
    {
    }
}