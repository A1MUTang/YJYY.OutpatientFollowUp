using System.Collections.Generic;
using System.IO;
using Furion;
using Furion.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using OutPatientFollowUp.Application;
using SqlSugar;
using StackExchange.Profiling.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace OutPatientFollowUp.Web.Core;

public class Startup : AppStartup
{
    private readonly IConfiguration _configuration;

    public Startup()
    {
          var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>();

        services.AddCorsAccessor();
        services.AddTransient<SMShandle>();
        services.AddSingleton<ISqlSugarClient>(s =>
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = _configuration.GetConnectionString("DefaultConnection"),
                IsAutoCloseConnection = true,
            },
           db =>
           {
               //单例参数配置，所有上下文生效
               db.Aop.OnLogExecuting = (sql, pars) =>
               {
                   //获取作IOC作用域对象
                   var appServive = s.GetService<IHttpContextAccessor>();
                   Log.Information($"【SQL语句】：{sql} \r\n 【参数】：{pars.ToJson()}");
               };
               db.Aop.OnError = (exp) =>//SQL报错
               {
                   //获取原生SQL推荐 5.1.4.63  性能OK
                   //UtilMethods.GetNativeSql(exp.sql,exp.parameters)
                   //获取无参数SQL对性能有影响，特别大的SQL参数多的，调试使用
                   Log.Error($"【SQL报错】：{exp.Sql} \r\n 【参数】：{exp.Parametres.ToJson()}");
               };
           });
            return sqlSugar;
        });
        services.AddControllers()
                .AddInjectWithUnifyResult<CustomResponseProvider>()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
                });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInject(string.Empty);
        app.UseStaticFiles(new StaticFileOptions
        {
            //下面设置可以下载apk和nupkg类型的文件
            ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
            {
                { ".apk","application/vnd.android.package-archive"},  
                { ".html","text/html"},  
                { ".js","application/javascript"},  
                { ".css","text/css"},  
                { ".gif","image/gif"},  
                { ".jpg","image/jpeg"},  
                { ".png","image/png"},  
                { ".woff","application/font-woff"},  
                { ".woff2","application/font-woff2"},  
                { ".ttf","application/font-sfnt"},  
                { ".eot","application/vnd.ms-fontobject"},  
                { ".otf","application/font-sfnt"},  
                { ".svg","image/svg+xml"},  
                { ".ico","image/x-icon"},  
                { ".json","application/json"},  
                { ".map","application/json}"}
            }),
            FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "OutpatientFollowUpUserAgreement")),
            RequestPath = "/outpatient-follow-up-user-agreement"
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
