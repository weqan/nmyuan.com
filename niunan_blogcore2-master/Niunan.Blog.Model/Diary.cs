using System;
namespace Niunan.Blog.Model
{
	/// <summary>diary表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-09-26 20:26:45
	/// </summary> 
	public partial class Diary
	{
		public Diary()
		{}
		private int _id ;
		/// <summary>日记表
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private DateTime _createtime ;
		/// <summary>创建时间
		/// 
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		private string _title ;
		/// <summary>标题
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		private string _body ;
		/// <summary>内容
		/// 
		/// </summary>
		public string body
		{
			set{ _body=value;}
			get{return _body;}
		}
	}
}
