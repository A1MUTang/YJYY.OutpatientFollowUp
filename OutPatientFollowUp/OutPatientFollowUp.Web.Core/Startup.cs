using System;
using Furion;
using Furion.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlSugar;

namespace OutPatientFollowUp.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>();

        services.AddCorsAccessor();
        services.AddSingleton<ISqlSugarClient>(s =>
        {
             SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
             {
                DbType = SqlSugar.DbType.Sqlite,
                ConnectionString = "DataSource=sqlsugar-dev.db",
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
