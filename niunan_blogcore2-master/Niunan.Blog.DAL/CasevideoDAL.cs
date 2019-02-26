using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using System.Data.Common;
namespace Niunan.Blog.DAL
{
    /// <summary>`casevideo`表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-26 16:12:45
    /// </summary>
    public partial class CasevideoDAL
    {
        public string ConnStr { set; get; }
        public CasevideoDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Niunan.Blog.Model.Casevideo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into `casevideo`(");
            strSql.Append("createdate, img, url, body, title, showdefault, visitnum, price, keyword, descn, remark, xsnum, sort  )");
            strSql.Append(" values (");
            strSql.Append("@createdate, @img, @url, @body, @title, @showdefault, @visitnum, @price, @keyword, @descn, @remark, @xsnum, @sort  )");
            strSql.Append(";select @@IDENTITY");
 
    using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.QuerySingle<int>(strSql.ToString(), model);
                return i;
            }
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Niunan.Blog.Model.Casevideo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update `casevideo` set ");
            strSql.Append("createdate=@createdate, img=@img, url=@url, body=@body, title=@title, showdefault=@showdefault, visitnum=@visitnum, price=@price, keyword=@keyword, descn=@descn, remark=@remark, xsnum=@xsnum, sort=@sort  ");
            strSql.Append(" where id=@id ");
       using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString(), model);
                return i > 0;
            }
        }

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public bool UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update `casevideo` set "+str_set +" "); 
            strSql.Append(" where "+cond);
               using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from `casevideo` ");
            strSql.Append(" where id=@id ");
         using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {

                int i = connection.Execute(strSql.ToString(), new { id = id });
                return i > 0;
            }
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from `casevideo` ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
                 using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }
		
        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public string GetOneFiled(string filed, string cond)
        {
            string sql = "select " + filed + " from `casevideo`";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
			
             using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = connection.ExecuteScalar<string>(sql);
                return tmp;
            }
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Niunan.Blog.Model.Casevideo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `casevideo` ");
            strSql.Append(" where id=@id ");
             Niunan.Blog.Model.Casevideo model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.Blog.Model.Casevideo>(strSql.ToString(), new { id=id });

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Niunan.Blog.Model.Casevideo GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `casevideo` ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
            strSql.Append(" limit 1;");
        Niunan.Blog.Model.Casevideo model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.Blog.Model.Casevideo>(strSql.ToString());

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<Niunan.Blog.Model.Casevideo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM `casevideo` ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Niunan.Blog.Model.Casevideo> list = new List<Niunan.Blog.Model.Casevideo>();
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.Blog.Model.Casevideo>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<Niunan.Blog.Model.Casevideo> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        { 

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}",strWhere);
 
			    string sql = string.Format("select {0} from `casevideo` {1} order by {2} limit {3},{4}", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
          

            List<Niunan.Blog.Model.Casevideo> list = new List<Niunan.Blog.Model.Casevideo>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.Blog.Model.Casevideo>(sql).ToList();

            }
            return list;
        }

 

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond )
        {
            string sql = "select count(1) from `casevideo`";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
         using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.QuerySingle<int>(sql);
                return i;

            }
        }
 
    }
}

