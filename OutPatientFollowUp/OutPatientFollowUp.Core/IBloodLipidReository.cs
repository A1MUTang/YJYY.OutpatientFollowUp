
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core;
public interface IBloodLipidReository : IBaseRepository<HT_Bloodlipid>
{
    /// <summary>
    ///  根据档案号获取最近血脂信息
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <returns></returns>
    public Task<HT_Bloodlipid> GetByArchivesCodeAsync(string archivesCode);
}