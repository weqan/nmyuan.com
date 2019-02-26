using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Niunan.Blog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class LogController : BaseController
    {
        DAL.LogDAL dal;

        public LogController(DAL.LogDAL bdal)
        {
            this.dal = bdal;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string start, string end)
        {

            string cond = "1=1";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                cond += $" and (ip like '%{key}%' or ipaddress like '%{key}%')";
            }
            if (!string.IsNullOrEmpty(start))
            {
                DateTime d;
                if (DateTime.TryParse(start, out d))
                {
                    cond += $" and createdate>='{d.ToString("yyyy-MM-dd")}'";
                }
            }
            if (!string.IsNullOrEmpty(end))
            {
                DateTime d;
                if (DateTime.TryParse(end, out d))
                {
                    cond += $" and createdate<='{d.ToString("yyyy-MM-dd")}'";
                }
            }
            return cond;
        }

        /// <summary>
        /// 取总记录数
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTotalCount(string key, string start, string end)
        {
            int totalcount = dal.CalcCount(GetCond(key, start, end));
            return Content(totalcount.ToString());
        }

        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public IActionResult List(int pageindex, int pagesize, string key, string start, string end)
        {
            List<Model.Log> list = dal.GetListArray("*","id desc", pagesize, pageindex, GetCond(key, start, end));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                arr.Add(new
                {
                    id = item.id, 
                    type = item.type == 0?"后台":"前台",
                    createDate = item.createdate.ToString("yyyy-MM-dd HH:mm"),
                    userName = item.username,
                    remark = item.remark,
                    ip = item.ip,
                    ipAddress = item.ipaddress,
                });
            }
            return Json(arr);
        }

 

        [HttpPost]
        public IActionResult Del(int id)
        {
            bool b = dal.Delete(id);
            if (b)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败，请联系管理员！");
            }
        }


    }
}
