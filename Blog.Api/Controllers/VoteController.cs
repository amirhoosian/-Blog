using Blog.Application.Interface;
using Blog.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private IVote _vote;

        public VoteController(IVote vote)
        {
            _vote = vote;
        }


        [HttpPost]
        public IActionResult AddVote(AddVoteVewModel vm)
        {
            _vote.AddVote(vm);
            return Ok(vm);
        }

        [HttpDelete]
        public IActionResult DeletedVote(int id)
        {
            _vote.RemoveVote(id);
            return Ok(id);
        }



    }
}
