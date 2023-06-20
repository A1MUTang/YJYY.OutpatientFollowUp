using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;
public class BloodLipidReository : BaseRepository<HT_Bloodlipid>, IBloodLipidReository
{
    public BloodLipidReository(ISqlSugarClient context) : base(context)
    {

    }
    public async Task<HT_Bloodlipid> GetByArchivesCodeAsync(string archivesCode)
    {
        return await Context.Queryable<HT_Bloodlipid>().OrderByDescending(x => x.CreateDate).FirstAsync(x => x.ArchivesCode == archivesCode);
    }
}