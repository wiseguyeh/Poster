using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poster.Models.Entities
{
    /// <summary>
    /// A user of the system.
    /// </summary>
    public class User : Entity
    {
        public virtual String Name { get; set; }
        public virtual String Password { get; set; }
    }
}
