using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;
public class SY_CityRepository : BaseRepository<SY_City>, ISY_CityRepository
{
    public SY_CityRepository(ISqlSugarClient sugarClient) : base(sugarClient)
    {
    }

    public  async Task<SY_City> GetCityAsync(string code)
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


    public SY_City GetCity(string code)
    {
        if (!string.IsNullOrEmpty(code))
        {
            return Context.Queryable<SY_City>()
                .Where(x => x.CODE == code)
                .Select(x => new SY_City
                {
                    CITY = x.CITY,
                    PROVINCE = x.PROVINCE
                })
                .First();
        }
        else
        {
            return new SY_City();
        }
    }

    public IEnumerable<SY_City> GetCityList()
    {
        return Context.Queryable<SY_City>().ToList();
    }

    public IEnumerable<SY_City> GetCityListByParentID(string parentid)
    {
        if (!string.IsNullOrEmpty(parentid) && parentid != "-1" && parentid.Length > 2)
        {
            string strPrefix = parentid.Substring(0, 2); //前缀
            string strSuffix = parentid.Substring(2, 4); //后缀 
                                                         //根据市编码的前缀确定其所包括的地级市和县
            string strCityPrefix = parentid.Substring(0, 4); //前缀
            string whereSql = "";
            if (strSuffix.Equals("0000"))
            {
                whereSql = $"SUBSTRING(CODE,1,2)={strPrefix} AND SUBSTRING(CODE,5,2)='00' AND CODE<>{parentid}";
            }
            else
            {
                whereSql = $"SUBSTRING(CODE,1,4)={strCityPrefix} AND CODE<>{parentid}";
            }
            return Context.Queryable<SY_City>()
                .Where(whereSql)
                .OrderBy(x => x.CODE)
                .Select(x => new SY_City
                {
                    CITY = x.CITY,
                    CODE = x.CODE
                })
                .ToList();
        }
        else
        {
            return null;
        }
    }
}