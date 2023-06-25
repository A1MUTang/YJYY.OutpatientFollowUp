using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_BloodOxygenReository : BaseRepository<HT_BloodOxygen>, IHT_BloodOxygenReository
{
    private readonly ISqlSugarClient _context;

    public HT_BloodOxygenReository(ISqlSugarClient context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// 根据档案编号和测量日期获取血氧信息。
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <param name="measureDate"></param>
    /// <returns></returns>
    public async Task<HT_BloodOxygen> GetByArchivesCode(string archivesCode)
    {
        return await _context.Queryable<HT_BloodOxygen>()
            .OrderByDescending(x => x.CreateDate)
            .Where(x => x.ArchivesCode == archivesCode )
            .FirstAsync();
    }
}