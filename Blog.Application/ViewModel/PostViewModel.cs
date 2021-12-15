using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModel
{
    public class AddpostViewModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
    public class UpdatepostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}
