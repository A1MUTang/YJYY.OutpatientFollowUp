// namespace OutPatientFollowUp.Application
// {
//     public class IdAppService : ISingleton
//     {
//         /// <summary>
//         /// 今天第一次得ID吗?
//         /// </summary>
//         private static bool isToday = true;
//         private static int startNum = 1;

//         private static readonly Object LockObj = new object();

//         /// <summary>
//         /// 获取主键ID
//         /// </summary>
//         /// <param name="strTable">表名</param>
//         /// <returns></returns>
//         public static string getManageID(string strTable)
//         {
//             string[] selectProperties = new string[] { SF_IDManage_Description.SID_Code, SF_IDManage_Description.SID_Bit, SF_IDManage_Description.SID_LastDate, SF_IDManage_Description.SID_LastNum };
//             var map = SingletonHelper<ModelDAL<SF_IDManage>>.Instance.Mapping;
//             string whereSql = string.Format(@"#{0}=@{0} ", SF_IDManage_Description.SID_Table);
//             object[] values = new object[] { strTable };
//             var result = map.Select(whereSql, values, false, selectProperties);

//             string strCode = "";
//             string ID = string.Empty;
//             string SeqNo = string.Empty;
//             if (result != null && result.Any())
//             {
//                 BllSF_IDManage.UpdateNum(result.First(), strTable);
//                 strCode = result.First().SID_Code.ToString();
//                 switch (result.First().SID_Bit.ToString())
//                 {
//                     case "4":
//                         { SeqNo = string.Format("{0:0000}", startNum); }
//                         break;
//                     case "5":
//                         { SeqNo = string.Format("{0:00000}", startNum); }
//                         break;
//                     case "6":
//                         { SeqNo = string.Format("{0:000000}", startNum); }
//                         break;

//                     default: { SeqNo = string.Format("{0:0000}", startNum); } break;
//                 }
//             }
//             else
//             {
//                 Insert(out strCode, strTable);
//                 SeqNo = string.Format("{0:000}", startNum);
//             }
//             if (strCode.Length > 3)
//             {
//                 ID = strCode.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd") + SeqNo;
//             }
//             else
//             {
//                 ID = strCode + DateTime.Now.ToString("yyyyMMdd") + SeqNo;
//             }
//             return ID;
//         }
//         /// <summary>
//         /// 第一次插入一条
//         /// </summary>
//         /// <param name="strCode"></param>
//         /// <param name="strTable"></param>
//         private static void Insert(out string strCode, string strTable)
//         {
//             strCode = "";
//             var map = SingletonHelper<ModelDAL<SF_IDManage>>.Instance.Mapping;
//             SP_pkeysProc proc = new SP_pkeysProc();
//             proc.table_name = strTable;
//             DataTable dt = new DataTable();
//             dt = (DataTable)map.ExecuteDataTable(proc);
//             if (dt != null && dt.Rows.Count > 0)
//             {
//                 strCode = dt.Rows[0]["COLUMN_NAME"].ToString();
//                 string strID;
//                 if (strTable == "SF_IDManage")
//                 {
//                     strID = "SID00000000000";
//                 }
//                 else
//                 {
//                     strID = getManageID("SF_IDManage");
//                 }
//                 SF_IDManage modelmanage = new SF_IDManage();
//                 modelmanage.SID_ID = strID;
//                 modelmanage.SID_Table = strTable;
//                 if (strCode.Length > 3)
//                 {
//                     modelmanage.SID_Code = strCode.Substring(0, 3);
//                 }
//                 else
//                 {
//                     modelmanage.SID_Code = strCode;
//                 }
//                 modelmanage.SID_LastNum = 1;
//                 modelmanage.SID_LastDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
//                 map.Insert(modelmanage);
//             }

//         }

//         /// <summary>
//         /// 更新一条
//         /// </summary>
//         /// <param name="dr"></param>
//         private static void UpdateNum(SF_IDManage manage, string strTable)
//         {
//             var map = SingletonHelper<ModelDAL<SF_IDManage>>.Instance.Mapping;
//             SF_IDManage modelmanage = new SF_IDManage();
//             string lastDate = manage.SID_LastDate.ToString();
//             isToday = (DateTime.Parse(lastDate).Date == DateTime.Now.Date) ? true : false;
//             object[] values = new object[] { strTable };
//             string sql = string.Format(@"#{0}=@{0}  ", SF_IDManage_Description.SID_Table);
//             if (isToday) //今天不是第一次得ID
//             {
//                 var datanum = map.Select(sql, values, false, new string[] { SF_IDManage_Description.SID_LastNum });
//                 if (datanum != null && datanum.Any())
//                 {
//                     modelmanage.SID_LastNum = datanum.First().SID_LastNum + 1;
//                 }
//                 else
//                 {
//                     modelmanage.SID_LastNum = 1;
//                 }
//                 startNum = (int)manage.SID_LastNum + 1;
//             }
//             else //今天第一次得ID
//             {
//                 modelmanage.SID_LastDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
//                 modelmanage.SID_LastNum = 1;
//             }
//             map.Update(modelmanage, sql, values);
//         }
//         public static string getManageIDNewstring(string strTable, string strcode)
//         {
//             lock (LockObj)
//             {
//                 if (!string.IsNullOrEmpty(strTable))
//                 {
//                     var map = SingletonHelper<ModelDAL<SF_IDManage>>.Instance.Mapping;
//                     ProcGetHtpatientID getid = new ProcGetHtpatientID();
//                     getid.TABLETYPE = strTable;
//                     var result = (DataTable)map.ExecuteDataTable(getid);
//                     if (result != null && result.Rows.Count > 0)
//                     {
//                         var States = result.Rows[0]["States"].ToString();
//                         var Statesno = States.PadLeft(5, '0');
//                         return strcode + DateTime.Now.ToString("yyyyMMdd") + Statesno;
//                     }
//                     else
//                     {
//                         return null;
//                     }
//                 }
//                 else
//                 {
//                     return null;
//                 }
//             }
//         }

//     }
// }