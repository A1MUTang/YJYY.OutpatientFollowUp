
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class PT_DoctorBasicInfoRepositroy : BaseRepository<PT_DoctorBasicInfo>, IPT_DoctorBasicInfoRepositroy<PT_DoctorBasicInfo>
{
    public PT_DoctorBasicInfoRepositroy(ISqlSugarClient context) : base(context)
    {
    }
}