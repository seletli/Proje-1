using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.UI.Attribute;
using System;
using System.Web.Mvc;

namespace TubeRehber.UI.Areas.Member.Controllers
{
    [Roles(Role.Member)]
    public class BaseController : Controller
    {
        
            protected MemberService _memberService = new MemberService();

        protected Guid userID { get { return _memberService.GetIDByUserName(HttpContext.User.Identity.Name); } }
    }
    
}