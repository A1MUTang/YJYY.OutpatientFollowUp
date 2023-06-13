using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 患者基本信息仓储类。
/// </summary>
public class HT_PatientBasicInfoRepository : BaseRepository<HT_PatientBasicInfo>, IHT_PatientBasicInfoRepository
{
    private readonly ISqlSugarClient _context;

    public HT_PatientBasicInfoRepository(ISqlSugarClient context) : base(context)
    {
        _context = context;
    }

    public  async Task<HT_PatientBasicInfo> GetByArchivesCode(string archivesCode,string manageName)
    {
        return await _context.Queryable<HT_PatientBasicInfo>()
            .Where(x => x.ArchivesCode == archivesCode && x.PBI_ManageUnit == manageName)
            .FirstAsync();
    }

    /// <summary>
    /// 根据身份证号和管理单位名称获取患者基本信息。
    /// </summary>
    /// <param name="idcard"></param>
    /// <param name="manageName"></param>
    /// <returns></returns>
    public async Task<HT_PatientBasicInfo> GetByIdcardAndDocterIdAsync(string idcard, string manageName)
    {
        return await _context.Queryable<HT_PatientBasicInfo>()
            .Where(x => x.PBI_ICard == idcard && SqlFunc.Subqueryable<PT_OrgnameForParent>()
                .Where(y => y.OrgName == manageName)
                .Select(y => y.ManageName)
                .Contains(x.PBI_ManageUnit))
            .FirstAsync();
    }

    /// <summary>
    /// 判断身份证号在管理单位下是否存在。
    /// </summary>
    /// <param name="idcard"></param>
    /// <param name="manageName"></param>
    /// <returns>true 已存在 false 不存在</returns>
    public async Task<bool> ExistIdCardByManageName(string idcard, string manageName)
    {
        return await _context.Queryable<HT_PatientBasicInfo>()
            .Where(x => x.PBI_ICard == idcard && SqlFunc.Subqueryable<PT_OrgnameForParent>()
                .Where(y => y.OrgName == manageName)
                .Select(y => y.ManageName)
                .Contains(x.PBI_ManageUnit))
            .CountAsync() > 0;

    }

    /// <summary>
    /// 插入患者基本信息
    /// </summary>
    /// <param name="patientBasicInfo"></param>
    /// <returns></returns>
    public new async Task<HT_PatientBasicInfo> InsertAsync(HT_PatientBasicInfo patientBasicInfo)
    {
        return await _context.Insertable(patientBasicInfo).IgnoreColumns(ignoreNullColumn: true).ExecuteReturnEntityAsync();
    }

    /// <summary>
    /// 更新患者基本信息
    /// </summary>
    /// <remarks>仅修改不为空的字段</remarks>
    /// <param name="patientBasicInfo"></param>
    // /// <returns></returns>
    // public new async Task<bool> UpdateAsync(HT_PatientBasicInfo patientBasicInfo)
    // {
    //     return await _context.Updateable(patientBasicInfo).IgnoreColumns(ignoreAllNullColumns: true).WhereColumns(it => new { it.ArchivesCode }).ExecuteCommandAsync() > 0;
    // }


    public new async Task<HT_PatientBasicInfo> UpdateAsync(HT_PatientBasicInfo patientBasicInfo)
    {
        await _context.Updateable<HT_PatientBasicInfo>(patientBasicInfo).Where(it => it.ArchivesCode == patientBasicInfo.ArchivesCode).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        return await _context.Queryable<HT_PatientBasicInfo>().FirstAsync(x => x.ArchivesCode == patientBasicInfo.ArchivesCode);
    }

}
