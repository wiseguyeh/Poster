using System;
using NHibernate;
using Poster.Models.Entities;

//THIS FILE HAS BEEN AUTOMATICALLY GENERATED, DO NOT MODIFY 
//generated @ 09/19/2010 21:43:15
namespace Poster.Models.Dao.NHibernate
{
	///<summary>
	/// NHibernate implementation of the IPostDao.
	///</summary>
	public partial class PostDao : NHibernateBaseDao<Post>, IPostDao
	{
	}

	///<summary>
	/// NHibernate implementation of the IUserDao.
	///</summary>
	public partial class UserDao : NHibernateBaseDao<User>, IUserDao
	{
	}

}
