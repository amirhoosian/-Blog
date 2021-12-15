using Blog.DataLayer.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entites
{

    public class Comment :BaseEnttiy
    {

        #region property
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }

        #endregion
        public User User { get; set; }
        public Post Post { get; set; }

    }
}
