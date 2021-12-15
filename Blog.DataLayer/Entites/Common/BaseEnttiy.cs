using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entites.Common
{
    public abstract class BaseEnttiy
    {
        public int Id { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
