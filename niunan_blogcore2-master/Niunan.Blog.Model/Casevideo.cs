using System;
namespace Niunan.Blog.Model
{
	/// <summary>casevideo表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-12-26 16:12:45
	/// </summary> 
	public partial class Casevideo
	{
		public Casevideo()
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
		private string _img ;
		/// <summary>
		/// 
		/// </summary>
		public string img
		{
			set{ _img=value;}
			get{return _img;}
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
		private string _body ;
		/// <summary>
		/// 
		/// </summary>
		public string body
		{
			set{ _body=value;}
			get{return _body;}
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
		private int _showdefault  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int showdefault
		{
			set{ _showdefault=value;}
			get{return _showdefault;}
		}
		private int _visitnum  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int visitnum
		{
			set{ _visitnum=value;}
			get{return _visitnum;}
		}
		private double _price  = 0;
		/// <summary>
		/// 
		/// </summary>
		public double price
		{
			set{ _price=value;}
			get{return _price;}
		}
		private string _keyword ;
		/// <summary>
		/// 
		/// </summary>
		public string keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		private string _descn ;
		/// <summary>
		/// 
		/// </summary>
		public string descn
		{
			set{ _descn=value;}
			get{return _descn;}
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
		private int _xsnum  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int xsnum
		{
			set{ _xsnum=value;}
			get{return _xsnum;}
		}
		private double _sort  = 0;
		/// <summary>
		/// 
		/// </summary>
		public double sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
	}
}
