using System.Collections.Generic;
using System;
using SqlSugar;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public class PT_MeasureEquipmentRepository : BaseRepository<PT_EquipMentVersionManage>, IPT_MeasureEquipmentRepository
    {
        private readonly ISqlSugarClient _context;
        public PT_MeasureEquipmentRepository(ISqlSugarClient context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Test>> GetUpdateInfo(string eqpNo, string apkType, string parentName, string unitName)
        {
            // 查询条件参数
            var result = await _context.Queryable<PT_EquipMentVersionManage>()
                .Where(m => m.IsRevoke == 0 || m.IsRevoke == null)
                .Where(m => m.EffectTime < DateTime.Now)
                .Where(m => m.EqpNo == eqpNo 
                || (m.ParentName == "全部" 
                    && m.ApkType == apkType 
                    && (m.EqpNo == "" 
                        || m.EqpNo == null)) 
                || (m.ParentName == parentName 
                    && m.ApkType == apkType 
                    && (m.UnitName == "全部" || m.UnitName == unitName) 
                    && (m.EqpNo == "" || m.EqpNo == null)))
                .OrderBy(m => SqlFunc.IIF(m.EqpNo == eqpNo, 1, SqlFunc.IIF(m.ParentName == parentName, 2, SqlFunc.IIF(m.ParentName == "全部", 3, 4))))
                .OrderBy(m => m.EffectTime, OrderByType.Desc)
                .Select(m => new Test
                {
                    ID = m.ID,
                    ApkType = m.ApkType,
                    ApkUrl = m.ApkUrl,
                    VersionNumber = m.VersionNumber,
                    DescribeInfo = m.DescribeInfo
                })
                .ToListAsync();
            return result;
        }
    }

    public class Test
    {
        public string ID { get; set; }

        public string ApkType { get; set; }

        public string ApkUrl { get; set; }

        public string VersionNumber { get; set; }

        public string DescribeInfo { get; set; }
    }
}