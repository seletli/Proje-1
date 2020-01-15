using TubeRehber.Core.Entity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TubeRehber.Core.Entity
{
    public class CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Status Status { get; set; }


        //Loglama.

        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }

        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }

    }
}
