using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_BlutdruckTempRepository : IBaseRepository<HT_BlutdruckTemp>
    {
        /// <summary>
        /// 根据档案编号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        public Task<HT_BlutdruckTemp> GetByArchivesCode(string archivesCode, string manageName);

        /// <summary>
        /// 根据身份证号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="manageName"></param>
        /// <returns></returns>
        public Task<HT_BlutdruckTemp> GetByIdcardAndDocterIdAsync(string idcard, string manageName);
    }
}