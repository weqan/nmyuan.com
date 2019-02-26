using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.Logging;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.IO;

namespace Niunan.Blog.Web
{
    public class Startup
    {

        //log4net日志
        public static ILoggerRepository repository { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //加载log4net日志配置文件
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //取出appsetting.json中的数据库连接字符串
            string connStr = Configuration.GetSection("ConnStr").Value;

            //注入
            services.AddSingleton<DAL.AdminDAL>(new DAL.AdminDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.BlogDAL>(new DAL.BlogDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.CategoryDAL>(new DAL.CategoryDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.LogDAL>(new DAL.LogDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.DiaryDAL>(new DAL.DiaryDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.CasevideoDAL>(new DAL.CasevideoDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.ShuqianDAL>(new DAL.ShuqianDAL() { ConnStr = connStr });

            //添加gb2312的支持
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });


            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add<Models.HttpGlobalExceptionFilter>(); //加入全局异常类
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
