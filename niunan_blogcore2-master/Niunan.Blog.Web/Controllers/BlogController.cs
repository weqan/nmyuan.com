using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Niunan.Blog.Web.Controllers
{
    /// <summary>
    /// 前台博客控制器
    /// </summary>
    public class BlogController : Controller
    {
        DAL.BlogDAL dal;
        DAL.CategoryDAL cadal;

        public BlogController(DAL.BlogDAL bdal, DAL.CategoryDAL cadal)
        {
            this.dal = bdal;
            this.cadal = cadal;
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string month, string cabh)
        {

            string cond = "1=1";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                cond += $" and title like '%{key}%'";
            }
            if (!string.IsNullOrEmpty(month))
            {
                DateTime d;
                if (DateTime.TryParse(month + "-01", out d))
                {
                    cond += $" and createdate>='{d.ToString("yyyy-MM-dd")}' and createdate<'{d.AddMonths(1).ToString("yyyy-MM-dd")}'";
                }
            }
            if (!string.IsNullOrEmpty(cabh))
            {
                cabh = Tool.GetSafeSQL(cabh);
                cond += $" and cabh='{cabh}'";
            }
            return cond;
        }

        /// <summary>
        /// 取博客总记录数
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTotalCount(string key, string month, string cabh)
        {
            int totalcount = dal.CalcCount(GetCond(key, month, cabh));
            return Content(totalcount.ToString());
        }


        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public IActionResult List(int pageindex, int pagesize, string key, string month, string cabh)
        {
            List<Model.Blog> list = dal.GetListArray("*","sort asc,id desc", pagesize, pageindex, GetCond(key, month, cabh));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                arr.Add(new
                {
                    id = item.id,
                    title = item.title,
                    createDate = item.createdate.ToString("yyyy-MM-dd HH:mm"),
                    caName = item.caname,
                    desc = Tool.ReplaceHtmlTag(item.body, 60),
                });
            }
            return Json(arr);
        }


        /// <summary>
        /// 显示博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Show(int id)
        {
            ViewBag.blogdal = dal;

            ViewBag.calist = cadal.GetIndexLeft_Ca();
            ViewBag.blogmonth = cadal.GetIndexLeft_Month();

            Model.Blog b = dal.GetModel(id);
            if (b == null)
            {
                return Content("找不到该博客！");
            }
            return View(b);
        }

    }
}
