using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModel
{
    public class AddVoteVewModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public bool IsLike { get; set; }
    }
    public class UpdateVoteVewModel
    {
        public int Id { get; set;}
        public int UserId { get; set; }
        public int PostId { get; set; }

        public bool IsLike { get; set; }
    }
}
