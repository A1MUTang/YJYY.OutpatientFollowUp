using Furion.Authorization;
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
    public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
    {
        // 获取 Authorization header 中的 token
        var authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();
        if (authorizationHeader == null || !authorizationHeader.StartsWith("Bearer "))
        {
            // 如果 Authorization header 不存在或格式不正确，则拒绝访问
            return Task.FromResult(false);
        }

        var token = authorizationHeader.Substring("Bearer ".Length);

        try
        {
            // 验证 token
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your_secret_key_here")),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            SecurityToken validatedToken;
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // 将用户信息存储到 HttpContext.User 中
            httpContext.User = claimsPrincipal;

            return Task.FromResult(true);
        }
        catch (Exception)
        {
            // 如果 token 验证失败，则拒绝访问
            return Task.FromResult(false);
        }
    }
}
