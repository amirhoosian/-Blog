using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModel
{
    public class AddCommentViewModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
    }
    public class UpdateCommentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
    }
}
