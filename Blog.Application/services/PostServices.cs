using Blog.Application.Enum;
using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.services
{
    public class PostServices : IPost
    {
        private readonly applicationContext _context;

        public PostServices(applicationContext context)
        {
            _context = context;
        }

        public async Task<Result> AddPost(AddpostViewModel vm)
        {
            Post newpost = new()
            {
                Title = vm.Title,
                Text = vm.Text,
                Description = vm.Description
                
            };
           
            await _context.AddAsync(newpost);
            await _context.SaveChangesAsync();
            return Result.Success;

        }

        public void DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
                return;
            _context.Remove(post);
            _context.SaveChanges();
            
        }

        public async Task<Result> UpdatePost(UpdatepostViewModel vm)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(c => c.Id == vm.Id);
            if (post == null)
                return Result.NotFound;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Text = vm.Text;
            _context.Update(post);
            await _context.SaveChangesAsync();

            return Result.Success;
        }
    }
}
