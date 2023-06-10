using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;
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
        .Select((c, t) => new { c.SCT_ID, c.SYC_ID, c.SYC_Name, t.SCT_Name })
        .ToListAsync();
        var grouplist = list.GroupBy(x => x.SCT_Name).ToList();
        var result = new List<Dictionary<string, string[][]>>();
        foreach (var item in grouplist)
        {
            var dic = new Dictionary<string, string[][]>();
            if(!string.IsNullOrEmpty(item.Key))
            dic.Add(item.Key, item.Select(x => new string[] { x.SYC_ID.ToString(), x.SYC_Name }).ToArray());
            result.Add(dic);
        }
        // var type =  grouplist.Select(x => new Dictionary<string, string[][]>
        // {
        //     {x.Key, x.Select(y => new string[] {y.SYC_ID.ToString(), y.SYC_Name}).ToArray()}
        // }).ToList();


        return result;
    }

}