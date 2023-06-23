using System.Threading.Tasks;
using Furion;
using SqlSugar;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血压仓储类。
    /// </summary>
    public class HT_BlutdruckTempRepository : BaseRepository<HT_BlutdruckTemp>, IHT_BlutdruckTempRepository
    {
        private readonly ISqlSugarClient _context;

        public HT_BlutdruckTempRepository(ISqlSugarClient context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据档案编号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        public async Task<HT_BlutdruckTemp> GetByArchivesCode(string archivesCode)
        {
            return await _context.Queryable<HT_BlutdruckTemp>()
                .OrderByDescending(x => x.CreateDate)
                .Where(x => x.ArchivesCode == archivesCode )
                .FirstAsync();
        }

    }
}