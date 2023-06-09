using Newtonsoft.Json;
using ServiceReference1;
using System.Text.Json;
namespace OutPatientFollowUp.Application;

public class SMShandle
{
    public static Service1SoapClient service = new Service1SoapClient(Service1SoapClient.EndpointConfiguration.Service1Soap);

    /// <summary>
    /// 取得一个6位的随机码
    /// </summary>
    /// <returns></returns>
    public static string GetRandomCode()
    {
        //return Guid.NewGuid().ToString().Substring(0, 4);

        Random rd = new Random();
        int Code = rd.Next(100000, 1000000);
        return Code.ToString(); ;
    }
    public void SendSM(string tel, string data)
    {
        //Common.IsLogin(this);

        //CommonFunction.update_data();

        //var msm = new ServiceReference1.Service1SoapClient();
        /*
        账号:dlzhuoxin
        密码:QrH7hr6T   
        产品信息类型 1012808 
        */
        CSubmitState state = service.g_SubmitAsync("dlzhuoxin", "QrH7hr6T", "", "1012808", tel, data + "【社区健康管理平台】").Result;
        string str = state.MsgID + ":" + state.MsgState;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tel"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool APPSendSM(string tel, string data)
    {
        /*
        账号:dlzhuoxin
        密码:QrH7hr6T   
        产品信息类型 1012808 
        */
        CSubmitState state = service.g_SubmitAsync("dlzhuoxin", "QrH7hr6T", "", "1012808", tel, data + "【医家医】").Result;
        //string str = state?.MsgID + ":" + state?.MsgState;
        //string path = HttpContext.Current.Request.PhysicalApplicationPath + "\\logs";
        //string filename = path + "/sendMsg.txt";//用日期对日志文件命名
        if (state == null || state?.MsgID == "0")
        {
            return false;
        }           
        return true;
    }
}
