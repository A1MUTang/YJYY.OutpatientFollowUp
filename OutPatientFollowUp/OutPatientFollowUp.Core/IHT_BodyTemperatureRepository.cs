using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_BodyTemperatureRepository: IBaseRepository<HT_BodyTemperature>
    {
        /// <summary>
        /// 根据档案编号和管理单位名称获取血压信息。
        /// </summary>
        /// <param name="archivesCode">档案编号</param>
        /// <returns></returns>
        public Task<HT_BodyTemperature> GetByArchivesCode(string archivesCode);

    }
}