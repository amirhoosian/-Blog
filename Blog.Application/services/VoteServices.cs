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
    public class VoteServices : IVote
    {
        private readonly applicationContext _context;

        public VoteServices(applicationContext context)
        {
            _context = context;
        }

        public void AddVote(AddVoteVewModel vm)
        {
            Vote vote = new Vote()
            {
                IsLike = true
            };
          _context.Add(vote);
            _context.SaveChanges();

        }

        public void RemoveVote(int id)
        {
            var vote = _context.Votes.Find(id);
            _context.Remove(vote);
            _context.SaveChanges();
        }
    }
}
