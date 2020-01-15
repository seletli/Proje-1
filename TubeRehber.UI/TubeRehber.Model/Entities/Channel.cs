using TubeRehber.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeRehber.Model.Entities
{
    public class Channel : CoreEntity
    {
        public Channel()
        {
            Comments = new List<Comment>();
            
        }
        public string ChannelName { get; set; }
        public string ChannelLink { get; set; }
        public int Rating { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        




    }
}
