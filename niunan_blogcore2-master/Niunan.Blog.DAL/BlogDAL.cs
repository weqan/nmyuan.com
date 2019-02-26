using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using System.Data.Common;
namespace Niunan.Blog.DAL
{
    /// <summary>`blog`表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-10-18 21:20:56
    /// </summary>
    public partial class BlogDAL
    {
        /// <summary>
        /// 数据库连接字符串，从web层传入
        /// </summary>
        public string ConnStr { set; get; }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Niunan.Blog.Model.Blog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into `blog`(");
            strSql.Append("createdate, title, body, body_md, visitnum, cabh, caname, remark, sort, updatetime  )");
            strSql.Append(" values (");
            strSql.Append("@createdate, @title, @body, @body_md, @visitnum, @cabh, @caname, @remark, @sort, @updatetime  )");
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
        public bool Update(Niunan.Blog.Model.Blog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update `blog` set ");
            strSql.Append("createdate=@createdate, title=@title, body=@body, body_md=@body_md, visitnum=@visitnum, cabh=@cabh, caname=@caname, remark=@remark, sort=@sort, updatetime=@updatetime  ");
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
            strSql.Append("update `blog` set "+str_set +" "); 
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
            strSql.Append("delete from `blog` ");
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
            strSql.Append("delete from `blog` ");
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
            string sql = "select " + filed + " from `blog`";
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
        public Niunan.Blog.Model.Blog GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `blog` ");
            strSql.Append(" where id=@id ");
             Niunan.Blog.Model.Blog model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.Blog.Model.Blog>(strSql.ToString(), new { id=id });

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Niunan.Blog.Model.Blog GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `blog` ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
            strSql.Append(" limit 1;");
        Niunan.Blog.Model.Blog model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.Blog.Model.Blog>(strSql.ToString());

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<Niunan.Blog.Model.Blog> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM `blog` ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Niunan.Blog.Model.Blog> list = new List<Niunan.Blog.Model.Blog>();
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.Blog.Model.Blog>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<Niunan.Blog.Model.Blog> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        { 

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}",strWhere);
 
			    string sql = string.Format("select {0} from `blog` {1} order by {2} limit {3},{4}", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
          

            List<Niunan.Blog.Model.Blog> list = new List<Niunan.Blog.Model.Blog>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.Blog.Model.Blog>(sql).ToList();

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
            string sql = "select count(1) from `blog`";
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

