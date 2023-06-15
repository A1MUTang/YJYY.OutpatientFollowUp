using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface ISY_CityRepository : IBaseRepository<SY_City>
    {
        
        /// <summary>
        /// 根据编码获取城市
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<SY_City> GetCityAsync(string code);

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SY_City>> GetCityLisAsynct();

        /// <summary>
        /// 根据父级编码获取城市列表
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public Task<IEnumerable<SY_City>> GetCityListByParentIDAsync(string parentCode);

    }
}