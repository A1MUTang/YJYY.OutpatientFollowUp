using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Web.Core;

public class JwtHandler : AppAuthorizeHandler
{
    /// <summary>
    /// 重写 Handler 添加自动刷新收取逻辑
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task HandleAsync(AuthorizationHandlerContext context)
    {
        //获取token
        var token = context.GetCurrentHttpContext().Request.Headers["Authorization"].ToString();
        //解析token，获取过期时间
        var handler = new JwtSecurityTokenHandler();
        //删除 Bearer
        token = token.Replace("Bearer ", "");
        var jwtToken = handler.ReadJwtToken(token);
        // 获取过期时间
        var expires = jwtToken.ValidTo;
        // 获取当前时间
        // var now = DateTime.Now;
        var now = DateTime.UtcNow;
        // 获取过期时间和当前时间的时间差
        var timeSpan =expires - now;
        // 如果时间差小0，就自动刷新 token eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIyODc4MjI5YzM4NzY0ZGE2OWQ4Nzg5Y2RiZGRmNGM1NiIsIkFjY291bnQiOiLlvKDooYwiLCJNYW5hZ2VOYW1lIjoi6auY6KGA5Y6L5Y2P5LyaIiwiV29ya1VuaXRzIjoi57u_5Zyw6Ieq55Sx5rivIiwiZXhwIjoxNjg2NzIzOTg5LCJuYmYiOjE2ODY3MjM5MjksImlhdCI6MTY4NjcyMzkyOSwiaXNzIjoiWWlKaWFZaVl1biIsImF1ZCI6IllpSmlhWWlZdW4ifQ.l5SV5kV6Ho0kSIVLeQcfwwTMhSfyPdR128O34eWK6CU
        if (timeSpan.TotalSeconds < 0) 
        {
            if (JWTEncryption.AutoRefreshToken(context, context.GetCurrentHttpContext()))
            {
                // 刷新成功，将token设置到响应头中
                context.GetCurrentHttpContext().Request.Headers["Authorization"] = context.GetCurrentHttpContext().Response.Headers["access-token"];
                await base.HandleAsync(context);
            }
            else
            {
                context.Fail();
            }
        }
        else
        {
            await base.HandleAsync(context);
            //将访问token 刷新token，清空
            context.GetCurrentHttpContext().Response.Headers["access-token"] = "";
            context.GetCurrentHttpContext().Response.Headers["x-access-token"]= "";
        }

    }

    /// <summary>
    /// 验证管道，也就是验证核心代码
    /// </summary>
    /// <param name="context"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        // 检查权限，如果方法是异步的就不用 Task.FromResult 包裹，直接使用 async/await 即可

        return Task.FromResult(true);
    }
}
