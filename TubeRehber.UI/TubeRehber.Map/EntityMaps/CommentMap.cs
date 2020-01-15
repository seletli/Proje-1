using TubeRehber.Core.Map;
using TubeRehber.Model.Entities;


namespace TubeRehber.Map.EntityMaps
{
   public class CommentMap:CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");

            Property(comment => comment.comment).IsOptional().HasMaxLength(200);

            HasRequired(comment => comment.Channel)
                .WithMany(channel => channel.Comments)
                .HasForeignKey(comment => comment.ChannelID)
                .WillCascadeOnDelete(false);


            HasRequired(comment => comment.Member)
                .WithMany(member => member.Comments)
                .HasForeignKey(comment => comment.MemberID)
                .WillCascadeOnDelete(false);
            
                
        }
    }
}
