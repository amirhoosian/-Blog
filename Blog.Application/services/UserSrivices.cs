using Blog.Application.Interface;
using Blog.Application.ViewModel;
using myAspMiniProject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.services
{
    public class UserSrivices : IUser
    {
        private readonly ApplicationContext _context;

        public UserSrivices(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Result> AddUser(AddUserViewModel vm)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateUser(UpdateUserViewModel vm)
        {
            throw new NotImplementedException();
        }

        private class ApplicationContext
        {
        }
    }
}
