using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TubeRehber.UI.Controllers
{
    public class AccountController : Controller
    {
        MemberService _memberService = new MemberService();

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {

            if (ModelState.IsValid)
            {
                
                Member currentUser = _memberService.GetByDefault(user => user.UserName == data.UserName && user.Password == data.Password);

                if (currentUser != null)
                {
                    
                   

                    FormsAuthentication.SetAuthCookie(currentUser.UserName, true);

                   
                    if (currentUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (currentUser.Role==Role.Member)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                    
                   
                }

            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Index", "Anasayfa");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Member data)
        {

            if (_memberService.GetByDefault(user => user.UserName == data.UserName) != null)
            {
               // return RedirectToAction("Index", "Home");
                
                return View();
            }

            
            data.Role = Role.Member;
            _memberService.Add(data);
            _memberService.Save();

            return RedirectToAction("Index", "Home");
        }

    }
}
