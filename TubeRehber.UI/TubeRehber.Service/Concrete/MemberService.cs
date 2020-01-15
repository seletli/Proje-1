using TubeRehber.Model.Entities;
using TubeRehber.Service.Abstract;
using System;
namespace TubeRehber.Service.Concrete
{
   public class MemberService : BaseService<Member>
    {
        public Member GetuserByUserName(string userName)
        {
            return GetByDefault(member => member.UserName == userName);
        }

        public Guid GetIDByUserName(string userName) => GetByDefault(member => member.UserName == userName).ID;
    }
}
