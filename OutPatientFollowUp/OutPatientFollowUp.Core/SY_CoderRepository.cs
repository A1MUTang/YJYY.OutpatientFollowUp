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
            throw Oops.Oh("编码不能为空");

        return Context.Queryable<SY_Code>()
            .Where(x => x.SYC_Code == code)
            .Select(x => x.SYC_Name)
            .First();
    }

}

public static class SY_CoderRepositoryExtensions
{
    /// <summary>
    /// 获取字典
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetCodeName( string code)
    {
        return App.GetService<ISY_CoderRepository>().GetCodeName(code);
    }
}