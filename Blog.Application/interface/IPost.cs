using Blog.Application.Enum;
using Blog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interface
{
    public interface IPost
{
        public Task<Result> AddPost(AddpostViewModel vm);
        public Task<Result> UpdatePost(UpdatepostViewModel vm);
        public  void DeletePost(int id);
}
}
