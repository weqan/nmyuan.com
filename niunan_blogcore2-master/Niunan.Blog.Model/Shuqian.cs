using System;
namespace Niunan.Blog.Model
{
	/// <summary>shuqian表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-07-15 18:42:57
	/// </summary>
 
	public partial class Shuqian
	{
		public Shuqian()
		{}
		private int _id ;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private DateTime _createdate ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		private string _title ;
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		private string _url ;
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		private string _tag ;
		/// <summary>
		/// 
		/// </summary>
		public string tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		private int _isprivate  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int isprivate
		{
			set{ _isprivate=value;}
			get{return _isprivate;}
		}
	}
}
