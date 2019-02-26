using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Diagnostics;

namespace Niunan.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        //用于读取网站静态文件目录
        private IHostingEnvironment hostingEnv;

        DAL.CategoryDAL cadal;
        DAL.BlogDAL bdal;
        DAL.LogDAL logdal;

        public HomeController(DAL.CategoryDAL cadal, DAL.BlogDAL bdal, DAL.LogDAL logdal, IHostingEnvironment hostingEnv)
        {
            this.cadal = cadal;
            this.bdal = bdal;
            this.logdal = logdal;
            this.hostingEnv = hostingEnv;
        }


        public IActionResult Index(string key, string month, string cabh)
        {
            //Stopwatch sw = Stopwatch.StartNew();



            ViewBag.blogdal = bdal;

            ViewBag.calist = cadal.GetIndexLeft_Ca();
            ViewBag.blogmonth = cadal.GetIndexLeft_Month();

            ViewBag.search_key = key;
            ViewBag.search_month = month;
            ViewBag.search_cabh = cabh;

            string ip1 = HttpContext.Request.Headers["X-Real-IP"]; //取IP，NGINX中的配置里要写上

            //var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
            //string ip2 = feature.RemoteIpAddress.ToString();

            //string ip3 = HttpContext.Request.Headers["X-Forwarded-For"];

            //string all_header = "";
            //foreach (var item in HttpContext.Request.Headers.Keys)
            //{
            //    all_header += item + " → "+ HttpContext.Request.Headers[item];
            //}


            //不记录登录日志了
            //string ipfile = hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}qqwry.dat"; //IP纯真库物理路径
            //string ipaddress = string.IsNullOrEmpty(ip1) ? "" : Tool.GetIPAddress(ip1, ipfile);  //查IP纯真库
            //logdal.Add(new Model.Log
            //{
            //    createdate = DateTime.Now,
            //    type = 1,
            //    userid = 0,
            //    username = "访客",
            //    remark = "访客登录 ",
            //    ip = ip1,
            //    ipaddress = ipaddress
            //});

            //  sw.Stop();
            //long ll =  sw.ElapsedMilliseconds; //这个是总运行时间

            //  return Content($"总运行时间：{ll}");
            return View();
        }

    }
}
