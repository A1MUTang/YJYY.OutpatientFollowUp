using System.Collections.Generic;
using System.Text;
using Furion.DataValidation;
using Furion;
using Furion.FriendlyException;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Web.Core
{
    /// <summary>
    /// RESTful 风格返回值
    /// </summary>
    [UnifyModel(typeof(CustomResponse<>))]
    public class CustomResponseProvider : IUnifyResultProvider
    {
        /// <summary>
        /// 异常返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
        {
            return new JsonResult(YourRESTfulResult(metadata.StatusCode, data: metadata.Data, errors: metadata.Errors)
                , UnifyContext.GetSerializerSettings(context)); // 当前行仅限 Furion 4.6.6+ 使用
        }

        /// <summary>
        /// 成功返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult OnSucceeded(ActionExecutedContext context, object data)
        {
            return new JsonResult(YourRESTfulResult(StatusCodes.Status200OK, true, data)
                , UnifyContext.GetSerializerSettings(context)); // 当前行仅限 Furion 4.6.6+ 使用
        }

        /// <summary>
        /// 验证失败返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
        {
            var a = metadata.ValidationResult as Dictionary<string, string[]>;
            var errorMessage = new StringBuilder();
            if (a != null)
            {
                foreach (var item in a)
                {
                    var itemArray = item.Value;
                    errorMessage.Append(itemArray[0].ToString() + ";");
                }
                errorMessage.Remove(errorMessage.Length - 1, 1);
            }
            return new JsonResult(YourRESTfulResult(metadata.StatusCode ?? StatusCodes.Status400BadRequest, data: metadata.Data, errors: errorMessage)
                , UnifyContext.GetSerializerSettings(context)); // 当前行仅限 Furion 4.6.6+ 使用
        }

        /// <summary>
        /// 特定状态码返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="statusCode"></param>
        /// <param name="unifyResultSettings"></param>
        /// <returns></returns>
        public async Task OnResponseStatusCodes(HttpContext context, int statusCode, UnifyResultSettingsOptions unifyResultSettings)
        {
            // 设置响应状态码
            UnifyContext.SetResponseStatusCodes(context, statusCode, unifyResultSettings);

            switch (statusCode)
            {
                // 处理 401 状态码
                case StatusCodes.Status401Unauthorized:
                    await context.Response.WriteAsJsonAsync(YourRESTfulResult(statusCode, errors: "401 Unauthorized")
                        , App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                    break;
                // 处理 403 状态码
                case StatusCodes.Status403Forbidden:
                    await context.Response.WriteAsJsonAsync(YourRESTfulResult(statusCode, errors: "403 Forbidden")
                        , App.GetOptions<JsonOptions>()?.JsonSerializerOptions);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 返回 RESTful 风格结果集
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="succeeded"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static CustomResponse<object> YourRESTfulResult(int statusCode, bool succeeded = default, object data = default, object errors = default)
        {
            return new CustomResponse<object>
            {
                Code = statusCode,
                IsOK = succeeded,
                Data = data,
                Msg = errors?.ToString()
            };
        }
    }
}