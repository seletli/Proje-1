using TubeRehber.Core.Entity;
using System;
using System.Collections.Generic;



namespace TubeRehber.Model.Entities
{
    public enum Role
    {
        None=0,
        Admin=2,
        Member=4,
        Guest=6
         
    }
    public class Member:CoreEntity
    {
        public Member()
        {
            Comments = new List<Comment>();
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }




    }
}
