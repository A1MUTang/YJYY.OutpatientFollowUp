using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    /// <summary>
    /// 血糖仓储接口。
    /// </summary>
    public interface IHT_GlucoseRepository : IBaseRepository<HT_Glucose>
    {
        /// <summary>
        /// 根据档案编号和管理单位名称获取血糖信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        Task<HT_Glucose> GetByArchivesCode(string archivesCode);

        /// <summary>
        /// 根据身份证号和管理单位名称获取血糖信息。
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        Task<HT_Glucose> GetByIdcardAndDocterIdAsync(string idcard);
    }
}