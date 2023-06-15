using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public interface ICityAppService : ITransient
    {
        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SY_City>> GetCityListAsync(string code);

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SY_City>> GetProvinceListAsync();
        //TODO 根据城市获取对应的区县
    }
}