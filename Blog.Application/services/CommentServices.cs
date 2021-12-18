using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.services
{
    public class CommentServices : IComment
    {
        private readonly applicationContext _context;

        public CommentServices(applicationContext context)
        {
            _context = context;
        }

        public void AddComment(AddCommentViewModel vm)
        {
            Comment newcomment = new Comment()
            {
                Text = vm.Text
               
            };
            _context.Add(newcomment);
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            _context.Remove(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(UpdateCommentViewModel vm)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == vm.Id);
            if (comment == null)
                return;
            comment.Text = vm.Text;
            _context.Update(comment);
            _context.SaveChanges();
        }
    }
}
