using System.Threading.Tasks;

namespace OutPatientFollowUp.Core;
public interface IHT_PatientBasicInfoRepository : IBaseRepository<HT_PatientBasicInfo>
{
    /// <summary>
    /// 根据身份证号和管理单位名称获取患者基本信息。
    /// </summary>
    /// <param name="idCard"></param>
    /// <param name="manageName"></param>
    /// <returns></returns>
    public Task<HT_PatientBasicInfo> GetByIdcardAndDocterIdAsync(string idCard, string manageName);

    /// <summary>
    /// 判断身份证号在管理单位下是否存在。
    /// </summary>
    /// <param name="idCard"></param>
    /// <param name="manageName"></param>
    /// <returns>true 已存在 false 不存在</returns>
    public Task<bool> ExistIdCardByManageName(string idCard, string manageName);

    /// <summary>
    /// 插入患者基本信息
    /// </summary>
    /// <param name="patientBasicInfo"></param>
    /// <returns></returns>
    public new Task<HT_PatientBasicInfo> InsertAsync(HT_PatientBasicInfo patientBasicInfo);


    /// <summary>
    /// 更新患者基本信息
    /// </summary>
    /// <remarks>仅修改不为空的字段</remarks>
    /// <param name="patientBasicInfo"></param>
    /// <returns></returns>
    // public new Task<bool> UpdateAsync(HT_PatientBasicInfo patientBasicInfo);

    /// <summary>
    /// 更新患者基本信息
    /// </summary>
    /// <param name="patientBasicInfo">档案编号</param>
    /// <returns></returns>
    public new Task<HT_PatientBasicInfo> UpdateAsync(HT_PatientBasicInfo patientBasicInfo);

    /// <summary>
    /// 根据档案编号获取患者基本信息
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <param name="manageName"></param>
    /// <returns></returns>
    public Task<HT_PatientBasicInfo> GetByArchivesCode(string archivesCode,string manageName);
}