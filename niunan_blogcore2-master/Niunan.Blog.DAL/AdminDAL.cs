using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niunan.Blog.Model;

namespace Niunan.Blog.DAL
{
    /// <summary>
    /// 管理员表的数据库操作类
    /// </summary>
    public class AdminDAL
    {
        /// <summary>
        /// 数据库连接字符串，从web层传入
        /// </summary>
        public string ConnStr { set; get; }


        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public int Insert(Model.Admin m)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int resid = connection.Query<int>(
                    @"INSERT INTO admin
                       (username,password)
                 VALUES
                       ( @username,@password );SELECT @@IDENTITY;",
                    m).First();
                return resid;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {
            string sql = "select * from admin where username=@username and password=@password";
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            { 
                var m = connection.Query<Model.Admin>(sql,  new { username=username,password= password}).FirstOrDefault();
                return m;
            }
        }


        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Admin GetModel(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {

                var m = connection.Query<Model.Admin>("select * from admin where id = @id",

                  new { id = id }).FirstOrDefault();
                return m;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool UpdatePwd(string pwd, int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {

                int res = connection.Execute(@"UPDATE [admin]
                                                       SET [password]=@password
                                                     WHERE Id=@Id", new { password=pwd, id=id});

                if (res > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
