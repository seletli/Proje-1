using TubeRehber.Core.Entity;
using TubeRehber.Map.EntityMaps;
using TubeRehber.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;




namespace TubeRehber.DAL.Context
{
    public class TubeRehberContext:DbContext
    {
        public TubeRehberContext()
        {
            Database.Connection.ConnectionString = @"server=DESKTOP-NO32C4O\SQLEXPRESS;database=TubeRehberDB;Integrated Security=True";

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TubeRehberContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap ());
            modelBuilder.Configurations.Add(new ChannelMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new MemberMap());
            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Member> Members { get; set; }
        
        
        
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            string ip = Core.Service.RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Core.Entity.Enum.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedIP = ip;
                        entity.CreatedDate = date;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedIP = ip;
                        entity.ModifiedDate = date;
                    }
                }
            }
            
            return base.SaveChanges();
        }
    }
}
