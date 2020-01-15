using TubeRehber.Core.Map;
using TubeRehber.Model.Entities;

namespace TubeRehber.Map.EntityMaps
{
    public class ChannelMap:CoreMap<Channel>
    {
        public ChannelMap()
        {
            ToTable("dbo.Channels");
            Property(channel => channel.ChannelName).IsRequired().HasMaxLength(200);
              
            Property(channel => channel.Rating).IsOptional();
            

            










        }
    }
}
