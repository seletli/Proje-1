using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using TubeRehber.Core.Entity;



namespace TubeRehber.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);
            Property(x => x.Status).IsOptional();




            //Add
            Property(core => core.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.CreatedBy).IsOptional();
            //update
            Property(core => core.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.ModifiedBy).IsOptional();
        }
    }
    
   
}
