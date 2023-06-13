
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using System;
using System.Data;

namespace OutPatientFollowUp.Core;
public class SF_IDManageRepository : BaseRepository<SF_IDManage>, ISF_IDManageRepository
{

    /// <summary>
    /// 今天第一次得ID吗?
    /// </summary>
    private static bool isToday = true;
    private static int startNum = 1;

    private static readonly Object LockObj = new object();
    public SF_IDManageRepository(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
    {
    }

    public async Task<string> GetManangeID(string tableName)
    {
        Context.Ado.BeginTran();

        var result = await Context.Queryable<SF_IDManage>().TranLock(DbLockType.Wait).Where(x => x.SID_Table == tableName).ToListAsync();
        string strCode = "";
        string ID = string.Empty;
        string SeqNo = string.Empty;
        if (result != null && result.Any())
        {
            UpdateNum(result.First(), tableName);
            strCode = result.First().SID_Code.ToString();
            switch (result.First().SID_Bit.ToString())
            {
                case "4":
                    { SeqNo = string.Format("{0:0000}", startNum); }
                    break;
                case "5":
                    { SeqNo = string.Format("{0:00000}", startNum); }
                    break;
                case "6":
                    { SeqNo = string.Format("{0:000000}", startNum); }
                    break;

                default: { SeqNo = string.Format("{0:0000}", startNum); } break;
            }
        }
        else
        {
            strCode = await Insert(strCode, tableName);
            SeqNo = string.Format("{0:000}", startNum);
        }
        if (strCode.Length > 3)
        {
            ID = strCode.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd") + SeqNo;
        }
        else
        {
            ID = strCode + DateTime.Now.ToString("yyyyMMdd") + SeqNo;
        }
        Context.Ado.CommitTran();
        return ID;
    }


    public async Task<string> GetNewManangeID(string tableName, string strcode)
    {
        Context.Ado.BeginTran();
        if (string.IsNullOrEmpty(tableName))
        {
            return null;
        }

        var nameP = new SugarParameter("@TABLETYPE", tableName);
        var result = await Context.Ado.UseStoredProcedure().GetDataTableAsync("GetHtpatientID", nameP);

        if (result?.Rows.Count > 0)
        {
            var states = result.Rows[0]["States"].ToString().PadLeft(5, '0');
            return strcode + DateTime.Now.ToString("yyyyMMdd") + states;
        }
        Context.Ado.CommitTran();
        return null;

    }

    /// <summary>
    /// 更新一条
    /// </summary>
    private async void UpdateNum(SF_IDManage manage, string strTable)
    {
        if (manage is null)
        {
            throw new ArgumentNullException(nameof(manage));
        }

        string lastDate = manage.SID_LastDate.ToString();
        isToday = (DateTime.Parse(lastDate).Date == DateTime.Now.Date) ? true : false;
        var values = new { SID_Table = strTable };
        if (isToday) //今天不是第一次得ID
        {
            var datanum = Context.Queryable<SF_IDManage>().TranLock(DbLockType.Wait)
                .Where(x => x.SID_Table == strTable)
                .Select(x => x.SID_LastNum)
                .ToList();
            if (datanum != null && datanum.Any())
            {
                manage.SID_LastNum = datanum.First() + 1;
            }
            else
            {
                manage.SID_LastNum = 1;
            }
            startNum = (int)manage.SID_LastNum + 1;
        }
        else //今天第一次得ID
        {
            manage.SID_LastDate = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));
            manage.SID_LastNum = 1;
        }
        Context.Updateable(manage)
            .Where(x => x.SID_Table == strTable)
            .UpdateColumns(x => new { x.SID_LastDate, x.SID_LastNum })
            .ExecuteCommand();
    }
    private async Task<string> Insert(string strCode, string tableName)
    {
        var nameP = new SugarParameter("@table_name", tableName);
        var result = await Context.Ado.UseStoredProcedure().GetDataTableAsync("sp_pkeys", nameP);

        if (result != null && result.Rows.Count > 0)
        {
            strCode = result.Rows[0]["COLUMN_NAME"].ToString();
            string strID = tableName == "SF_IDManage" ? "SID00000000000" : await GetManangeID("SF_IDManage");
            SF_IDManage modelmanage = new SF_IDManage
            {
                SID_ID = strID,
                SID_Table = tableName,
                SID_Code = strCode.Length > 3 ? strCode.Substring(0, 3) : strCode,
                SID_LastNum = 1,
                SID_LastDate = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"))
            };
            await Context.Insertable(modelmanage).ExecuteCommandAsync();
        }
        return strCode;
    }
}