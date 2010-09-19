using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poster.Models.Entities
{
    /// <summary>
    /// A story/message/note that a user has created.
    /// </summary>
    public class Post : Entity
    {
        public virtual String Title { get; set; }
        public virtual String Content { get; set; }
        public virtual bool IsPrivate { get; set; }
        public virtual User Owner { get; set; }
    }
}
