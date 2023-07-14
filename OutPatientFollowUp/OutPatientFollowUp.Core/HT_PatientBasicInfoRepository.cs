using System.Threading.Tasks;
using Furion;
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

    public async Task<HT_PatientBasicInfo> GetByArchivesCode(string archivesCode, string manageName)
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
    public async Task<HT_PatientBasicInfo> GetByIdCardAndDoctorIdAsync(string idcard, string manageName)
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

    public async Task<HT_PatientBasicInfo> UpdateBasicInfoAsync(HT_PatientBasicInfo patientBasicInfo)
    {
        var oldBasicInfo = await _context.Queryable<HT_PatientBasicInfo>().FirstAsync(x => x.ArchivesCode == patientBasicInfo.ArchivesCode);
        await _context.Updateable<HT_PatientBasicInfo>(patientBasicInfo).Where(it => it.ArchivesCode == patientBasicInfo.ArchivesCode)
            .UpdateColumns(it =>
                new
                {
                    it.PBI_PersonPhone,
                    it.IsSdrug,
                    it.IsHdrug,
                }).ExecuteCommandAsync();
        return await _context.Queryable<HT_PatientBasicInfo>().FirstAsync(x => x.ArchivesCode == patientBasicInfo.ArchivesCode);
    }


    public new async Task<HT_PatientBasicInfo> UpdateAsync(HT_PatientBasicInfo patientBasicInfo)
    {
        var oldBasicInfo = await _context.Queryable<HT_PatientBasicInfo>().FirstAsync(x => x.ArchivesCode == patientBasicInfo.ArchivesCode);
        await _context.Updateable<HT_PatientBasicInfo>(patientBasicInfo).Where(it => it.ArchivesCode == patientBasicInfo.ArchivesCode)
            .UpdateColumns(it =>
                new
                {
                    it.PBI_Gender,
                    it.PBI_DrinkingStatus,
                    it.PBI_Birthday,
                    it.PBI_BMI,
                    it.PBI_ChronicDiseaseType,
                    it.PBI_ShiYanLiang,
                    it.PBI_YinShiKouWei,
                    it.PBI_YunDongXiGuan,
                    it.PBI_FamilyDiseaseType,
                    it.PBI_ZhiFangSheRuLiang,
                    it.PBI_ShuiGuoSheRuLiang,
                    it.PBI_MuBiaoSGSheRuLiang,
                    it.PBI_Height,
                    it.PBI_MuBiaoZFSheRuLiang,
                    it.PBI_TunWei,
                    it.PBI_MarryState,
                    it.PBI_ChronicDiseaseOther,
                    it.PBI_BaoXiaoFangShi,
                    it.PBI_AgeType,
                    it.PBI_FeelBad,
                    it.PBI_KongYanLiang,
                    it.PBI_ShuiMinShiJian,
                    it.PBI_ShuiMinXiGuan,
                    it.PBI_SmokingStatus,
                    it.PBI_ShuCiSheRuLiang,
                    it.PBI_MuBiaoSCSheRuLiang,
                    it.PBI_YaoWei,
                    it.PBI_Weight,
                    it.PBI_YaoTunBi,
                    it.PBI_Nation,
                    it.PBI_UserName,
                    it.PBI_ICard,
                    it.PBI_PersonPhone,
                    it.PBI_IDCardAddress,
                    it.PBI_Province,
                    it.PBI_City,
                    it.PBI_County,
                    it.PBI_Address,
                    it.PBI_OriginPlace,
                    it.IsSdrug,
                    it.IsHdrug
                }
            ).ExecuteCommandAsync();
        return await _context.Queryable<HT_PatientBasicInfo>().FirstAsync(x => x.ArchivesCode == patientBasicInfo.ArchivesCode);
    }

    public HT_PatientBasicInfo GetByArchivesCode(string archivesCode)
    {
        return _context.Queryable<HT_PatientBasicInfo>().OrderByDescending(x => x.PBI_CreateDate).First(x => x.ArchivesCode == archivesCode);
    }
}


public static class HT_PatientBasicInfoRepositoryExtensions
{
    public static HT_PatientBasicInfo GetByArchivesCode(string archivesCode)
    {
        return App.GetService<IHT_PatientBasicInfoRepository>().GetByArchivesCode(archivesCode);
    }

}
