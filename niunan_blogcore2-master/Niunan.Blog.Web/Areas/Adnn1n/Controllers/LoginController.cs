using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Niunan.Blog.Web.Areas.Controllers
{
    [Area("Adnn1n")]
    public class LoginController : Controller
    {
        DAL.AdminDAL adal;

        public LoginController(DAL.AdminDAL adal) {
            this.adal = adal;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            username = Tool.GetSafeSQL(username);
            password = Tool.MD5Hash(password);

            Model.Admin a = adal.Login(username, password);
            if (a == null)
            {
                return Content("<script> alert('登录失败，用户名或者密码出错！'); location.href='/Adnn1n/Login'</script>", "text/html");
            }
            HttpContext.Session.SetInt32("adminid", a.Id);
            HttpContext.Session.SetString("adminusername", a.UserName);
            return Redirect("/Adnn1n/Home/Index");
        }


    }
}
