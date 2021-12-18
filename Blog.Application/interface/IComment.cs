using Blog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interface
{
    public interface IComment
{
        public void AddComment(AddCommentViewModel vm);
        public void DeleteComment(int id);
        public void UpdateComment(UpdateCommentViewModel vm);
}
}
