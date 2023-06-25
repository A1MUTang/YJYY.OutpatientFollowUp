using System;
using System.Threading.Tasks;
using Furion;
using SqlSugar;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 体温仓储类。
    /// </summary>
    public class HT_BodyTemperatureRepository : BaseRepository<HT_BodyTemperature>, IHT_BodyTemperatureRepository
    {
        private readonly ISqlSugarClient _context;

        public HT_BodyTemperatureRepository(ISqlSugarClient context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据档案编号和测量日期获取体温信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="measureDate"></param>
        /// <returns></returns>
        public async Task<HT_BodyTemperature> GetByArchivesCode(string archivesCode)
        {
            return await _context.Queryable<HT_BodyTemperature>()
                .OrderByDescending(x => x.CreateDate)
                .Where(x => x.ArchivesCode == archivesCode )
                .FirstAsync();
        }
    }
}