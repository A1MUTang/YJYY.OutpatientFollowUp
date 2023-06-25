using System.Threading.Tasks;

namespace OutPatientFollowUp.Core;
public interface IHT_BloodOxygenReository : IBaseRepository<HT_BloodOxygen>
{
    /// <summary>
    /// 根据档案编号和测量日期获取血氧信息。
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <returns></returns>
    Task<HT_BloodOxygen> GetByArchivesCode(string archivesCode);

}