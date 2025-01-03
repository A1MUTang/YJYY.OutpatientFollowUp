using System.Threading.Tasks;
using Furion.DatabaseAccessor;
using SqlSugar;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血糖仓储类。
    /// </summary>
    public class HT_GlucoseRepository : BaseRepository<HT_Glucose>, IHT_GlucoseRepository
    {
        private readonly ISqlSugarClient _context;
        public HT_GlucoseRepository(ISqlSugarClient context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据档案编号和管理单位名称获取血糖信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <returns></returns>
        public async Task<HT_Glucose> GetByArchivesCode(string archivesCode)
        {
            return await _context.Queryable<HT_Glucose>()
                .Where(x => x.ArchivesCode == archivesCode )
                .OrderBy(x => x.CreateDate, OrderByType.Desc)
                .FirstAsync();
        }

        /// <summary>
        /// 根据身份证号和管理单位名称获取血糖信息。
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public async Task<HT_Glucose> GetByIdCardAndDoctorIdAsync(string idCard)
        {
            return await _context.Queryable<HT_Glucose>()
                .Where(x => x.ICard == idCard && SqlFunc.Subqueryable<PT_OrgnameForParent>()
                    .Select(y => y.ManageName)
                    .Contains(x.CreateArchivesUnit))
                .FirstAsync();
        }
    }


}