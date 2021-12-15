using Blog.DataLayer.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entites
{
    public class Vote :BaseEnttiy
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public bool IsLike { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }  
        
    }
}
