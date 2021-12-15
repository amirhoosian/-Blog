using Blog.DataLayer.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entites
{
    public class User :BaseEnttiy
    {
        /// <summary>
        ///  تعریف پراپرتی های جدول یوزر
        /// </summary>

        #region property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
        #endregion

        public List<Post> Posts { get; set; }
        public List<Vote> votes { get; set; }
        public List<Comment> comments { get; set; }

       
    }
}
