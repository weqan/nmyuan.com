using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niunan.Blog.Model
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CaName { set; get; }
        /// <summary>
        /// 分类编号 
        /// </summary>
        public string Bh { set; get; }
        /// <summary>
        /// 父编号
        /// </summary>
        public string Pbh { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}
