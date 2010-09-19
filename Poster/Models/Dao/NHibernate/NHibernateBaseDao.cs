using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using NHibernate;
using System.Diagnostics.Contracts;

namespace Poster.Models.Dao.NHibernate
{
    /// <summary>
    /// NHibernate implementation of the IBaseDao, providing data operations common to all entities and the means for extending classes
    /// to provide specialized, interface-specific data operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class NHibernateBaseDao<T> : IBaseDao<T> where T : Entities.Entity
    {
        private ISession session;

        [Inject()]
        public ISession Session
        {
            private get {
                Contract.Requires<NHibernateSessionException>(session != null, "Session was null (Check dependency injection has been configured for ISession)");
                Contract.Requires<NHibernateSessionException>(!session.IsOpen, "ISession was closed");
                return session; 
            }
            set { session = value; }
        }

        public virtual void Create(T toCreate)
        {
            this.Session.Save(toCreate);
        }

        public void Delete(int entityId)
        {
            this.Session.Delete(String.Format("FROM {0} t WHERE t.Id = {1}", typeof(T).Name, entityId));
        }

        public virtual void Update(T toUpdate)
        {
            this.Session.Update(toUpdate);
        }

        public virtual T Get(int id)
        {
            return this.Session.Get<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Session.CreateQuery(String.Format("FROM {0}", typeof(T).Name)).List<T>();
        }

        public int Count
        {
            get 
            {
                return 0;
            }
        }

        public bool Exists(int entityId)
        {
            return this.Session.Get<T>(entityId) != null;
        }

        #region Inner classes
        public class NHibernateSessionException : Exception
        {

            public NHibernateSessionException(String message)
                : base("The Nhibernate session was not properly configured, failed because: " + message)
            {

            }
        }
        #endregion





    }

  
}