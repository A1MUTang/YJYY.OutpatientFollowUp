using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion;
using Furion.DatabaseAccessor;
using Furion.FriendlyException;
using SqlSugar;

namespace OutPatientFollowUp.Core;
public class SY_CoderRepository : BaseRepository<SY_Code>, ISY_CoderRepository
{
    public SY_CoderRepository(ISqlSugarClient context) : base(context)
    {
    }

    public async Task<List<Dictionary<string, string[][]>>> GetDicionary()
    {
        var list = await Context.Queryable<SY_Code, SY_CodeType>((c, t) => new object[]
        {
            JoinType.Left, c.SCT_ID == t.SCT_ID
        })
        .Select((c, t) => new { c.SCT_ID, c.SYC_ID, c.SYC_Name, t.SCT_Name, c.SYC_Code })
        .ToListAsync();
        var grouplist = list.GroupBy(x => x.SCT_Name).ToList();
        var result = new List<Dictionary<string, string[][]>>();
        foreach (var item in grouplist)
        {
            var dic = new Dictionary<string, string[][]>();
            if (!string.IsNullOrEmpty(item.Key))
                dic.Add(item.Key, item.Select(x => new string[] { x.SYC_Code.ToString(), x.SYC_Name }).ToArray());
            result.Add(dic);
        }

        return result;
    }

    public string GetCodeName(string code)
    {
        if (string.IsNullOrEmpty(code))
            return string.Empty;
        return Context.Queryable<SY_Code>()
            .Where(x => x.SYC_Code == code)
            .Select(x => x.SYC_Name)
            .First();
    }

    public List<string> GetCodesName(List<string> codes)
    {
        if (codes == null || codes.Count == 0)
            throw Oops.Oh("编码不能为空");

        return Context.Queryable<SY_Code>()
            .Where(x => codes.Contains(x.SYC_Code))
            .Select(x => x.SYC_Name)
            .ToList();
    }

    public string GetCodeByName(string codeName)
    {
        if (string.IsNullOrEmpty(codeName))
            return string.Empty;

        return  Context.Queryable<SY_Code>()
            .Where(x => x.SYC_Name == codeName)
            .Select(x => x.SYC_Code)
            .First();

    }

}

public static class SY_CoderRepositoryExtensions
{
    /// <summary>
    /// 获取字典名称
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetCodeName( string code)
    {
        try
        {
            return App.GetService<ISY_CoderRepository>().GetCodeName(code);

        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }

    /// <summary>
    /// 获取字典名称
    /// </summary>
    /// <param name="codes"></param>
    /// <returns></returns>
    public static string GetCodesName(string codes)
    {
        if (string.IsNullOrEmpty(codes))
                return string.Empty;

        List<string> codesList =  codes.Split(',').ToList();
        var nameList = App.GetService<SY_CoderRepository>().GetCodesName(codesList);
        return string.Join(',', nameList);
    }

    /// <summary>
    /// 根据名称获取编码
    /// </summary>
    /// <param name="codeName"></param>
    /// <returns></returns>
    public   static string GetCodeByName(string codeName)
    {
        return App.GetService<ISY_CoderRepository>().GetCodeByName(codeName);
    }


}