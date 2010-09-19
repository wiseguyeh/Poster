using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.Contracts;

namespace Poster.Models.Dao
{
    /// <summary>
    /// Defines common data operations that can be performed over all entities.
    /// </summary>
    [ContractClass(typeof(IBaseDaoContracts<>))]
    public interface IBaseDao<T> where T : Entities.Entity 
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="toCreate"></param>
        void Create(T toCreate);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="toDelete"></param>
        void Delete(int entityId);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="toUpdate"></param>
        void Update(T toUpdate);

        /// <summary>
        /// Fetches an existing entity. 
        /// If the entity does not exist for the specified id, an exception will be thrown.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        T Get(int entityId);

        /// <summary>
        /// Determines if an entity exists.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        bool Exists(int entityId);

        /// <summary>
        /// Fetches all entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns a count of the total number of entities.
        /// </summary>
        int Count { get; }
    }

    #region IBaseDao contract

    [ContractClassFor(typeof(IBaseDao<>))]
    public abstract class IBaseDaoContracts<T> : IBaseDao<T> where T : Entities.Entity
    {

        public void Create(T toCreate)
        {
            Contract.Requires<ArgumentNullException>(toCreate != null, "Cannot insert a null entity");
        }

        public void Delete(int entityId)
        {
            Contract.Requires<BadEntityIdException>(entityId > 0);
        }

        public void Update(T toUpdate)
        {
            Contract.Requires<ArgumentNullException>(toUpdate != null, "No entity to update was provided");
            Contract.Requires<BadEntityIdException>(toUpdate.Id > 0);
        }

        public T Get(int entityId)
        {
            Contract.Requires<BadEntityIdException>(entityId > 0);
            
            Contract.Ensures(Contract.Result<T>() != null, "The entity could not be found, please check an entity exists first with the Exists() method");
            return default(T);
        }

        public IEnumerable<T> GetAll()
        {
            return default(IEnumerable<T>);
        }

        public int Count
        {
            get {
                return default(int);
            }
        }


        public bool Exists(int entityId)
        {
            return default(bool);
        }
    }

#endregion

#region Contract exceptions

    public class BadEntityIdException : Exception
    {
        public BadEntityIdException()
            : base("The provided entity id was invalid- entity ids must be greater than zero") {}
    }


#endregion
}