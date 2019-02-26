using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.Blog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class CaseVideoController :BaseController
    {

        DAL.CasevideoDAL dal;

        public CaseVideoController(DAL.CasevideoDAL dal)
        {
            this.dal = dal;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string start, string end, string cabh)
        {

            string cond = "remark in ('video','case')";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                cond += $" and title like '%{key}%'";
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
            if (cabh != "0")
            {
                if (cabh == "1")
                {
                    cond += " and remark='case'";
                }
                else
                {
                    cond += " and remark='video'";
                }
            }
            return cond;
        }

        /// <summary>
        /// 取总记录数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTotalCount(string key, string start, string end, string cabh)
        {
            int totalcount = dal.CalcCount(GetCond(key, start, end, cabh));
            return Content(totalcount.ToString());
        }

        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult List(int pageindex, int pagesize, string key, string start, string end, string cabh)
        {
            List<Model.Casevideo> list = dal.GetListArray("*", "sort desc,id desc", pagesize, pageindex, GetCond(key, start, end, cabh));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                arr.Add(new
                {
                    id = item.id,
                    createdate = item.createdate.ToString("yyyy-MM-dd HH:mm"),
                    img = item.img,

                    title = item.title,
                    
                    visitnum = item.visitnum,
                    price = item.price,
                    remark = item.remark,
                    sort = item.sort,

                });
            }
            return Json(arr);
        }

        public ActionResult Add(int? id)
        {
            Model.Casevideo n = new Model.Casevideo() { createdate = DateTime.Now, sort=dal.CalcCount("")+1};
            if (id != null)
            {
                n = dal.GetModel(id.Value);
            }
            return View(n);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Model.Casevideo m)
        {
            try
            {
                if (m.id == 0)
                {
                    dal.Add(m);
                    return Json(new { code = 0, msg = "新增成功！" });
                }
                else
                {
                    dal.Update(m);
                    return Json(new { code = 0, msg = "编辑成功！" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }

        public ActionResult Delete(string ids)
        {
            try
            {
                int success = 0;
                string[] ss = ids.Split(',');
                foreach (var item in ss)
                {
                    int x;
                    if (int.TryParse(item, out x))
                    {
                        dal.Delete(x);
                        success++;
                    }
                }
                return Json(new { code = 0, msg = "成功删除" + success + "条记录！" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }
    }
}

