
namespace OutPatientFollowUp.Web.Core;
/// <summary>
/// 自定义错误信息
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class CustomResponse<T>
{
    /// <summary>
    /// 错误信息
    /// </summary>
    /// <value></value>
    public string Msg { get; set; }
    /// <summary>
    /// 错误码
    /// </summary>
    /// <value></value>
    public int Code { get; set; }
    /// <summary>
    /// 是否成功
    /// </summary>
    /// <value></value>
    public bool IsOK { get; set; }
    /// <summary>
    /// 扩展信息
    /// </summary>
    /// <value></value>
    public object Ext { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    /// <value></value>
    public T Data { get; set; }

    public CustomResponse(T data, object ext = null, string msg = "请求成功", int code = 200, bool isOK = true)
    {

        Msg = msg;
        Code = code;
        IsOK = isOK;
        Ext = ext;
        Data = data;
    }

    public CustomResponse()
    {
        Msg = "请求成功";
        Code = 200;
        IsOK = true;
    }
}
