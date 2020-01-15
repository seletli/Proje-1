using TubeRehber.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TubeRehber.Model.Entities
{
    public enum CommentStatus
    {
        None = 0,
        Completed = 2,
        Cancelled = 4,
        Declined = 6,
    }
    public  class Comment:CoreEntity
    {
       

        public string comment { get; set; }


        public Guid MemberID { get; set; }
        public virtual Member Member { get; set; }

        public Guid ChannelID { get; set; }
        public virtual Channel Channel { get; set; }

        

        


    }
}
