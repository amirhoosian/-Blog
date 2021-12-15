using Blog.DataLayer.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entites
{
    public class Post :BaseEnttiy
    {
        #region property
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        #endregion

        public User User { get; set; }
        public List<Vote> votes { get; set; }
        public List<Comment> comments { get; set; }

        
    }
}
