using Blog.Application.Enum;
using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPost _post;

        public PostController(IPost post)
        {
            _post = post;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddpostViewModel vm)
        {
            var post = await _post.AddPost(vm);
            switch (post)
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



      [HttpPost]
      public async Task<IActionResult> updatePost(UpdatepostViewModel vm)
        {
            var post = await _post.UpdatePost(vm);
            switch (post)
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




    [HttpDelete]
    public IActionResult RemovePost(int id)
        {
            _post.DeletePost(id);
            return Ok(id);
        }


    }
}
