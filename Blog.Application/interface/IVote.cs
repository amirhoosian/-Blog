using Blog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interface
{
    public interface IVote
{
        public void AddVote(AddVoteVewModel vm);
        public void RemoveVote(int id);    
}

    
}
