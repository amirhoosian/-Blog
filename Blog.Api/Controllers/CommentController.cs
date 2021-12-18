using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IComment _comment;
public CommentController(IComment comment)
        {
            _comment = comment;
        }


        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel vm)
        {
            _comment.AddComment(vm);
            return Ok(vm);
        }

        [HttpPost]
        public IActionResult UpdateComment(UpdateCommentViewModel vm) { 
        
            _comment.UpdateComment(vm);
            return Ok(vm);
        }


        [HttpDelete]
        public IActionResult DeletedComment(int id)
        {
            _comment.DeleteComment(id);
            return Ok(id);
        }




    }
}
