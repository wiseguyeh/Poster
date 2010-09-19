using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poster.Models.Entities
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// The id of the entity.
        /// </summary>
        public virtual int Id { get; private set; }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is  Entity)
            {
                result = ((Entity) obj).Id == this.Id;
            }
            return result;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return String.Format("{0}[{1}]", this.GetType().Name, this.Id);
        }
    }
}