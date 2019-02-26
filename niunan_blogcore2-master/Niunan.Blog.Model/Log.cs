using System;
namespace Niunan.Blog.Model
{
	/// <summary>log表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-07-16 10:39:30
	/// </summary> 
	public partial class Log
	{
		public Log()
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
		private int _type ;
		/// <summary>
		/// 
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		private int _userid ;
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		private string _username ;
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
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
		private string _ip ;
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		private string _ipaddress ;
		/// <summary>
		/// 
		/// </summary>
		public string ipaddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
	}
}
