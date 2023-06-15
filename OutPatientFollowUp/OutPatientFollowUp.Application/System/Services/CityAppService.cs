using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class CityAppService : ICityAppService
{
    private readonly ISY_CityRepository _cityRepository;
    public CityAppService(ISY_CityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    /// <summary>
    /// 获取城市列表
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<SY_City>> GetCityListAsync(string code)
    {
        var cityList = await _cityRepository.GetCityListByParentIDAsync(code);
        return cityList;
    }

    /// <summary>
    /// 获取省份列表
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<SY_City>> GetProvinceListAsync()
    {
        var provinceList = await _cityRepository.GetCityLisAsynct();
        return provinceList;
    }
    //TODO 根据城市获取对应的区县


    
}

