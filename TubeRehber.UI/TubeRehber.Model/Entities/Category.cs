using TubeRehber.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeRehber.Model.Entities
{
    public class Category : CoreEntity
    {
        

        public Category()
        {
            Channels = new List<Channel>();
        }
        public string CategoryName { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }


    }
}