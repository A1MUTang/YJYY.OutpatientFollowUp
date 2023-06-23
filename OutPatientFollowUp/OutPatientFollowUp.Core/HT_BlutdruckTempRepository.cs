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
        public async Task<HT_BlutdruckTemp> GetByArchivesCode(string archivesCode, string manageName)
        {
            return await _context.Queryable<HT_BlutdruckTemp>()
                .Where(x => x.ArchivesCode == archivesCode && x.CreateArchivesUnit == manageName)
                .FirstAsync();
        }

        /// <summary>
        /// 根据身份证号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        public async Task<HT_BlutdruckTemp> GetByIdcardAndDocterIdAsync(string idcard, string manageName)
        {
            return await _context.Queryable<HT_BlutdruckTemp>()
                .Where(x => x.ICard == idcard && SqlFunc.Subqueryable<PT_OrgnameForParent>()
                    .Where(y => y.OrgName == manageName)
                    .Select(y => y.ManageName)
                    .Contains(x.CreateArchivesUnit))
                .FirstAsync();
        }
    }
}