using Blog.Application.Enum;
using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Blog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel vm)
        {
            var user = await _user.AddUser(vm);
            switch (user)
            {
                case Result.Error:
                    return BadRequest("خطایی رخ داده است");
                case Result.NotFound:
                    return NotFound("کاربری یافت نشد");
                case Result.Success:
                    return Ok("عملیات با موفقیت انجام شد");
                default:
                    return Ok();
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel vm)
        {
            var user = await _user.UpdateUser(vm);
            switch (user)
            {
                case Result.Error:
                    return BadRequest("خطایی رخ داده است");
                case Result.Success:
                    return Ok("عملیات با موفقیت انجام شد");
                default:
                    return Ok();
            }

        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
             _user.DeleteUser(id);
           return Ok(id);

        }

        [HttpPost]
        public async Task<IActionResult> Login(AddUserViewModel vm)
        {
            var login = await _user.Login(vm);
            switch (login)
            {
                case Result.Error:
                    return BadRequest("خطایی رخ داده است");
                case Result.NotFound:
                    return NotFound("کاربری یافت نشد");
                case Result.Success:
                    return Ok("عملیات با موفقیت انجام شد");
                default:
                    return Ok();
            }
        }



    }
}
