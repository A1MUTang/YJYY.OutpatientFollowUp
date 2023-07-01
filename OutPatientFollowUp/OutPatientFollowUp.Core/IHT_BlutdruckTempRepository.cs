using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_BlutdruckTempRepository : IBaseRepository<HT_BlutdruckTemp>
    {
        /// <summary>
        /// 根据档案编号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <returns></returns>
        public Task<HT_BlutdruckTemp> GetByArchivesCode(string archivesCode);

    }
}