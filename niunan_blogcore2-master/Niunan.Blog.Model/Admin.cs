using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niunan.Blog.Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public class Admin
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
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 用户密码 
        /// </summary>
        public string Password { set; get; }
 
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}
