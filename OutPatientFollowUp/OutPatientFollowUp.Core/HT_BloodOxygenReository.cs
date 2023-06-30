using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_BloodOxygenRepository : BaseRepository<HT_BloodOxygen>, IHT_BloodOxygenRepository
{
    private readonly ISqlSugarClient _context;

    public HT_BloodOxygenRepository(ISqlSugarClient context) : base(context)
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