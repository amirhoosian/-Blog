using Blog.Application.ViewModel;
using myAspMiniProject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interface
{
   public interface IUser
{
        public Task<Result> AddUser(AddUserViewModel vm);
        public Task<Result> UpdateUser(UpdateUserViewModel vm);
        public void DeleteUser(int id);
}
}
