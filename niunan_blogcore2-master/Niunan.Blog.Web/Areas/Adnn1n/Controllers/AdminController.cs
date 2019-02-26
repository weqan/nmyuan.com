using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 

namespace Niunan.Blog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class AdminController : BaseController
    {
        DAL.AdminDAL adal;

        public AdminController(DAL.AdminDAL adal ) {
            this.adal = adal;
        }

        public IActionResult ModPwd() { return View(); }

        [AutoValidateAntiforgeryToken()]
        [HttpPost]
        public IActionResult ModPwd(string oldpwd,string newpwd,string newpwd2) {

            if (string.IsNullOrEmpty(oldpwd) || string.IsNullOrEmpty(newpwd) || string.IsNullOrEmpty(newpwd2) )
            {
                return Content("<script>alert('请把修改密码信息填写完整！');location.href='/Adnn1n/Admin/ModPwd'</script>", "text/html");
            }


            if (newpwd!= newpwd2)
            {
                return Content("<script>alert('二次密码输入不相同！');location.href='/Adnn1n/Admin/ModPwd'</script>", "text/html");
            }

            oldpwd = Tool.MD5Hash(oldpwd);
         



            int? adminid = HttpContext.Session.GetInt32("adminid");
            if (adminid == null)
            {
                //末登录
                return Redirect("/Adnn1n/Login/");
            }
            
            Model.Admin a = adal.GetModel(adminid.Value);
            if (a==null)
            {
                return Content("<script>alert('adminid不存在，请联系管理员！');location.href='/Adnn1n/Admin/ModPwd'</script>", "text/html");
            }
            if (a.Password != oldpwd)
            {
                return Content("<script>alert('原密码不正确！');location.href='/Adnn1n/Admin/ModPwd'</script>", "text/html");
            }

            a.Password =  Tool.MD5Hash(newpwd);
        bool b =    adal.UpdatePwd(a.Password, a.Id);

            if (b)
            {
                return Content("<script>alert('修改密码成功！');parent.location.href='/Adnn1n/Login'</script>", "text/html");
            }
            else
            {
                return Content("<script>alert('修改密码失败，请联系管理员！');location.href='/Adnn1n/Admin/ModPwd'</script>", "text/html");
            }



        }

    }
}
