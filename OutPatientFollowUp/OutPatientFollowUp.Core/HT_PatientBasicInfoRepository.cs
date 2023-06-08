using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;
/// <summary>
/// 患者基本信息仓储类。
/// </summary>
public class HT_PatientBasicInfoRepository : BaseRepository<HT_PatientBasicInfo>
{
    private readonly ISqlSugarClient _context;

    public HT_PatientBasicInfoRepository(ISqlSugarClient context) : base(context)
    {
        _context = context;
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
    public async Task<HT_PatientBasicInfo> Insert(HT_PatientBasicInfo patientBasicInfo)
    {
        return await _context.Insertable(patientBasicInfo).ExecuteReturnEntityAsync();
    }

    /// <summary>
    /// 更新患者基本信息
    /// </summary>
    /// <remarks>仅修改不为空的字段</remarks>
    /// <param name="patientBasicInfo"></param>
    /// <returns></returns>
    public async Task<bool> Update(HT_PatientBasicInfo patientBasicInfo)
    {
        return await _context.Updateable(patientBasicInfo).IgnoreColumns(ignoreAllNullColumns: true).Where(it => it.ArchivesCode == patientBasicInfo.ArchivesCode).ExecuteCommandAsync() > 0;
    }
    


}