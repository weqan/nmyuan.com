using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Niunan.Blog.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class CategoryController : BaseController
    {
        DAL.CategoryDAL dal;

        public CategoryController(DAL.CategoryDAL cadal) {
            this.dal = cadal;
        }

        public IActionResult Index()
        {
            #region 生成节点数据JSON
            ViewBag.nodejson = dal.GetTreeJson();
            #endregion
            ViewBag.calist = dal.GetList("");
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Del(int id)
        {
            bool b = dal.Delete(id);
            if (b)
            {
                return Content("删除成功！");
            }
            return Content("删除失败，请联系管理员！");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="caname"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(int pid, string caname)
        {
            caname = Tool.GetSafeSQL(caname);
            string pbh = "0";
            if (pid != 0)
            {
                Model.Category pca = dal.GetModel(pid);
                if (pca != null)
                {
                    if (pca.Pbh != "0")
                    {
                        return Json(new { status = "n", info = "最多只能添加二级分类！" });
                    }
                    pbh = pca.Bh;
                    if (dal.CalcCount($"pbh='{pca.Bh}' and caname='{caname}'") > 0)
                    {
                        return Json(new { status = "n", info = "已有同名分类，不准增加！" });
                    }
                }
            }
            else
            {
                if (dal.CalcCount($"pbh='0' and caname='{caname}'") > 0)
                {
                    return Json(new { status = "n", info = "已有同名分类，不准增加！" });
                }
            }
            string bh = dal.GenBH(pbh, 2);
            dal.Insert(new Model.Category() { CaName = caname, Pbh = pbh, Bh = bh, });
            return Json(new { status = "y", info = "新增分类成功！" });

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="caname"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Mod(int pid, string caname, int id)
        {
            Model.Category ca = dal.GetModel(id);
            if (ca == null)
            {
                return Json(new { status = "n", info = "分类ID传入错误！" });
            }

            string bh = ca.Bh;
            string pbh = ca.Pbh;

            int source_pid = ca.Pbh == "0" ? 0 :dal.GetModelByBh(ca.Pbh).Id ;//分类原本的父级ID

            Model.Category pca = dal.GetModel(pid);
            if (pca != null)
            {
                if (pca.Id != source_pid)
                {
                    //需要修改父级分类，重新生成编号
                    pbh = pca.Bh;
                    bh = dal.GenBH(pbh, 2);
                }
            }
            else if (pid == 0)
            {
                //设置为顶级分类
                pbh = "0";
                bh = dal.GenBH(pbh, 2);
            }

            ca.CaName = caname;
            ca.Bh = bh;
            ca.Pbh = pbh;
            bool b = dal.Update(ca);
            if (b)
            {
                return Json(new { status = "y", info = "分类修改成功！" });
            }
            else
            {
                return Json(new { status = "n", info = "分类修改失败，请联系管理员！" });
            }
        }
    }
}


