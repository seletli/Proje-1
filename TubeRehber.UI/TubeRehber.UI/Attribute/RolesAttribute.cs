using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TubeRehber.UI.Attribute
{
    public class RolesAttribute : AuthorizeAttribute
    {
       
        
            Role[] _roles;
            MemberService _memberService;
            public RolesAttribute(params Role[] roles)
            {
                _memberService = new MemberService();
                _roles = new Role[roles.Length];
                Array.Copy(roles, _roles, roles.Length);
            }

            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                

                string userName = HttpContext.Current.User.Identity.Name;

              

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    
                    Member currentUser = _memberService.GetByDefault(user => user.UserName == userName);

                    foreach (Role nextRole in _roles)
                    {
                        if (currentUser.Role == nextRole)
                        {
                            return true;
                        }
                    }

                    return false;
                }
               
                HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
                return false;
            }


            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectResult("~/Error/Unauthorized");
            }

        
    }
}