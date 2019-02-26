using System;
namespace Niunan.Blog.Model
{
	/// <summary>blog表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-10-18 21:20:56
	/// </summary> 
	public partial class Blog
	{
		public Blog()
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
		private string _body ;
		/// <summary>
		/// 
		/// </summary>
		public string body
		{
			set{ _body=value;}
			get{return _body;}
		}
		private string _body_md ;
		/// <summary>
		/// 
		/// </summary>
		public string body_md
		{
			set{ _body_md=value;}
			get{return _body_md;}
		}
		private int _visitnum ;
		/// <summary>
		/// 
		/// </summary>
		public int visitnum
		{
			set{ _visitnum=value;}
			get{return _visitnum;}
		}
		private string _cabh ;
		/// <summary>
		/// 
		/// </summary>
		public string cabh
		{
			set{ _cabh=value;}
			get{return _cabh;}
		}
		private string _caname ;
		/// <summary>
		/// 
		/// </summary>
		public string caname
		{
			set{ _caname=value;}
			get{return _caname;}
		}
		private string _remark ;
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		private int _sort ;
		/// <summary>
		/// 
		/// </summary>
		public int sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		private DateTime _updatetime = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
	}
}
