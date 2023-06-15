using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Furion;
using Furion.FriendlyException;
using SqlSugar;

namespace OutPatientFollowUp.Core;
public class SY_CityRepository : BaseRepository<SY_City>, ISY_CityRepository
{
    public SY_CityRepository(ISqlSugarClient sugarClient) : base(sugarClient)
    {
    }

    public async Task<SY_City> GetCityAsync(string code)
    {
        if (!string.IsNullOrEmpty(code))
        {
            return await Context.Queryable<SY_City>()
                .Where(x => x.CODE == code)
                .Select(x => new SY_City
                {
                    CITY = x.CITY,
                    PROVINCE = x.PROVINCE
                })
                .FirstAsync();
        }
        else
        {
            return new SY_City();
        }
    }

    public async Task<IEnumerable<SY_City>> GetCityLisAsynct()
    {

        return await Context.Queryable<SY_City>()
         .Where(x => x.CODE.Substring(2, 4) == "0000")
         .OrderBy(x => x.CODE)
         .Select(x => new SY_City
         {
             CODE = x.CODE,
             PROVINCE = x.PROVINCE
         })
         .ToListAsync();
    }
    
    public async Task<IEnumerable<SY_City>> GetCityListByParentNameAsync(string parentName)
    {
        if (!string.IsNullOrEmpty(parentName))
            throw Oops.Oh("父级名称不能为空");
        
        var code = GetCityNameByCode(parentName);
        if (!string.IsNullOrEmpty(code))
            code = GetProvinceCodeByName(parentName);
        return await GetCityListByParentIDAsync(code);
    }


    public async Task<IEnumerable<SY_City>> GetCityListByParentIDAsync(string parentCode)
    {
        if (!string.IsNullOrEmpty(parentCode) && parentCode != "-1" && parentCode.Length > 2)
        {
            string strPrefix = parentCode.Substring(0, 2); //前缀
            string strSuffix = parentCode.Substring(2, 4); //后缀 
                                                           //根据市编码的前缀确定其所包括的地级市和县
            string strCityPrefix = parentCode.Substring(0, 4); //前缀
            string whereSql = "";
            if (strSuffix.Equals("0000"))
            {
                whereSql = $"SUBSTRING(CODE,1,2)={strPrefix} AND SUBSTRING(CODE,5,2)='00' AND CODE<>{parentCode}";
            }
            else
            {
                whereSql = $"SUBSTRING(CODE,1,4)={strCityPrefix} AND CODE<>{parentCode}";
            }
            return await Context.Queryable<SY_City>()
                .Where(whereSql)
                .OrderBy(x => x.CODE)
                .Select(x => new SY_City
                {
                    CITY = x.CITY,
                    CODE = x.CODE
                })
                .ToListAsync();
        }
        else
        {
            return null;
        }
    }

    public string GetProvinceCodeByName(string code)
    {
        if (string.IsNullOrEmpty(code))
             return string.Empty;

        return Context.Queryable<SY_City>()
            .Where(x => x.CODE == code)
            .Select(x => x.PROVINCE)
            .First();
    }

    public string GetCityCodeByName(string code)
    {
        if (string.IsNullOrEmpty(code))
            return string.Empty;

        var city = Context.Queryable<SY_City>()
            .Where(x => x.CODE == code)
            .Select(x => x.CITY)
            .First();
        if(city == "直辖市")
        return "";
        else
        return city;
    }

    public string GetCityNameByCode(string name)
    {
        if (string.IsNullOrEmpty(name))
            return string.Empty;

        return Context.Queryable<SY_City>()
            .Where(x => x.CITY == name)
            .Select(x => x.CODE)
            .First();
    }

    public string GetProvinceNameByCode(string name)
    {
        if (string.IsNullOrEmpty(name))
            return string.Empty;

        return Context.Queryable<SY_City>()
            .Where(x => x.PROVINCE == name)
            .Select(x => x.CODE)
            .First();
    }

}


public static class CityRepositoryExtensions
{
    /// <summary>
    /// 获取省份名称
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetProvinceCodeName( string code)
    {
        return App.GetService<SY_CityRepository>().GetProvinceCodeByName(code);
    }

    /// <summary>
    /// 获取城市名称
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetCityCodeName(string code)
    {
        return App.GetService<SY_CityRepository>().GetCityCodeByName(code);
    }

    /// <summary>
    /// 获取城市编码
    /// </summary>
    public static string GetCityCodeByName(string name)
    {
        return App.GetService<SY_CityRepository>().GetCityNameByCode(name);
    }

    /// <summary>
    /// 获取省份编码
    /// </summary>
    public static string GetProvinceCodeByName(string name)
    {
        return App.GetService<SY_CityRepository>().GetProvinceNameByCode(name);
    }


}