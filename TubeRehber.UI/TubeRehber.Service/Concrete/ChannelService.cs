using TubeRehber.Model.Entities;
using TubeRehber.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TubeRehber.Service.Concrete
{
    public class ChannelService:BaseService<Channel>
    {
        public List<Channel> GetLatestChannel(int channelCount)
        {
            return _context.Channels.Where(channel => channel.Status == Core.Entity.Enum.Status.Active).OrderByDescending(channel => channel.CreatedDate).Take(channelCount).ToList();
        }

        public List<Channel> GetChannelsByChannelID(Guid id) => GetDefault(channel => channel.CategoryID == id && channel.Status == Core.Entity.Enum.Status.Active);

        public Channel GetChannelsByID(Guid id) => GetByDefault(channel => channel.ID == id);

        public Channel GetChannelByChannelLink(string Link)
        {
            return GetByDefault(x => x.ChannelLink == Link);
        }

        public Channel GetChannelByChannelName(string Name)
        {
            return GetByDefault(x => x.ChannelName == Name);
        }

    }
    
}
