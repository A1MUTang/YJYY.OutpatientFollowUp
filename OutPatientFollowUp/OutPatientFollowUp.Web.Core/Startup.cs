using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutPatientFollowUp.Application;
using SqlSugar;

namespace OutPatientFollowUp.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>();

        services.AddCorsAccessor();
        services.AddTransient<SMShandle>();
        services.AddSingleton<ISqlSugarClient>(s =>
        {//TODO:这里需要改为通过配置文件读取
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = "server=101.201.120.1;uid=sa;pwd=Yjyy968@bbw.com!@#;database=Hypertension; Trusted_Connection=no;Pooling=true;Max Pool Size=500; Min Pool Size=5;Connection Lifetime=300;Connect Timeout=500",
                IsAutoCloseConnection = true,
            },
           db =>
           {
               //单例参数配置，所有上下文生效
               db.Aop.OnLogExecuting = (sql, pars) =>
               {
                   //获取作IOC作用域对象
                   var appServive = s.GetService<IHttpContextAccessor>();
               };
           });
            return sqlSugar;
        });
        services.AddControllers()
                .AddInjectWithUnifyResult<CustomResponseProvider>();

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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
