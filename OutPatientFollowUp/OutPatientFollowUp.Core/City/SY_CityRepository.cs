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


    public string GetCodeName(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
           throw Oops.Oh("编码不能为空");
        }
         return Context.Queryable<SY_City>()
                .Where(x => x.CODE == code)
                .Select(x => x.CITY)
                .First();
    }


}


public static class CityAppServiceExtensions
{
    /// <summary>
    /// 获取字典
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetCodeName( string code)
    {
        return App.GetService<SY_CityRepository>().GetCodeName(code);
    }
}