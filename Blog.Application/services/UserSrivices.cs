using Blog.Application.Enum;
using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.services
{
    public class UserSrivices : IUser
    {
        private readonly applicationContext _context;

        public UserSrivices(applicationContext context)
        {
            _context = context;
        }

        public async Task<Result> AddUser(AddUserViewModel vm)
        {
            if (vm.PassWord != vm.ConfirmPassword)
            {
                return Result.Error;
            }

            var UserName = await _context.Users.SingleOrDefaultAsync(u => u.UserName == vm.UserName);
            if (UserName != null)
            {
                return Result.Error; ;
            }


            User newUser = new()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                UserName = vm.UserName,
                Email = vm.Email,
                PassWord = vm.PassWord,
                ConfirmPassword = vm.ConfirmPassword
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Result.Success;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            

        }

        public async Task<Result> UpdateUser(UpdateUserViewModel vm)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == vm.Id);
            if (user == null)
            {
                return Result.NotFound;
            }
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.UserName = vm.UserName;
            user.PassWord = vm.PassWord;
            user.ConfirmPassword = vm.ConfirmPassword;
            user.Email = vm.Email;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<Result> Login(AddUserViewModel vm)
        {
            var usr = await _context.Users.SingleOrDefaultAsync(u => u.UserName == vm.UserName && u.PassWord == vm.PassWord);
            if (usr != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(Authentication(usr.UserName, usr.PassWord, usr.Id));


                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.Name, vm.UserName)
                     }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Result.Success;
            }
            else
            {
                return Result.Error;
            }

        }
        private string Authentication(string username, string password, int Id)
        {
            if (!(username.Equals(username) || password.Equals(password)))
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes("asaaaaaaaaaaaaaa");

            //Find User For Login
            var user = _context.Users.FirstOrDefault(c => c.UserName == username);
            if (user == null)
            {
                //Return Error in Api ... You Can retrun Null
                return null;
            }

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.NameIdentifier, Id.ToString())

                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
