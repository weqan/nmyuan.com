using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niunan.Blog.Model;

namespace Niunan.Blog.DAL
{
    /// <summary>
    /// 分类表的数据库操作类
    /// </summary>
    public partial class CategoryDAL
    {
        /// <summary>
        /// 取首页左边的分类及分类文章数量
        /// </summary>
        /// <returns></returns>
        public List<Model.VM_IndexLeft> GetIndexLeft_Ca()
        {
            List<Model.VM_IndexLeft> list = null;
            string sql = "select category.bh,category.caname,count(1) as count from category " +
                        "inner join blog on category.bh = blog.cabh " +
                        "where pbh = '01' " +
                        "group by category.bh,category.caname";
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<VM_IndexLeft>(sql).ToList();
            }
            return list;
        }

        /// <summary>
        /// 取首页左边的月份及月份文章数量
        /// </summary>
        /// <returns></returns>
        public List<Model.VM_IndexLeft> GetIndexLeft_Month() {
            List<Model.VM_IndexLeft> list = null;
            string sql = "select DATE_FORMAT(createdate,'%Y-%m') as bh,count(1) as count "+
                            "from blog "+
                            "group by bh "+
                            "order by bh desc; ";
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<VM_IndexLeft>(sql).ToList();
            }
            return list;
        }


    }
}
