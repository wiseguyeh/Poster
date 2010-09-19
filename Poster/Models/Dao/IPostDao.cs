using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poster.Models.Dao
{
    public partial interface IPostDao
    {
        /// <summary>
        /// Fetches a list of all posts made by a particular user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Entities.Post> GetPostsByUser(int userId);
    }
}
