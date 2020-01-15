using TubeRehber.Core.Map;
using TubeRehber.Model.Entities;

namespace TubeRehber.Map.EntityMaps
{
    public class MemberMap:CoreMap<Member>
    {
        public MemberMap()
        {
            ToTable("dbo.Members");

            Property(member => member.Name).IsRequired().HasMaxLength(20);
            Property(member => member.SurName).IsRequired().HasMaxLength(20);
            Property(member => member.UserName).IsRequired().HasMaxLength(20);
            Property(member => member.BirthDate).IsRequired();
            Property(member => member.Email).IsRequired();
            Property(member => member.Role).IsRequired();
        }
    }
}
