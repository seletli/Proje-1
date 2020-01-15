using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TubeRehber.UI.Controllers
{
    public class PasswordRememberController : Controller
    {
        MemberService _memberService;

        public PasswordRememberController()
        {
            _memberService = new MemberService();
        }
        // GET: PasswordRemember
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Remember(string UserName,string Email)
        {
            if (UserName!=null && Email==null)
            {
                TubeRehber.Model.Entities.Member KullanıcıAdı = _memberService.GetuserByUserName(UserName);
                if (KullanıcıAdı==null)
                {
                    if (KullanıcıAdı.Email==Email)
                    {
                        ViewBag.Password = KullanıcıAdı.Password;
                        return View();
                    }
                }
                else { return RedirectToAction("Hata"); }
            }
            
            
            return RedirectToAction("Hata");
        }

        public ActionResult Hata()
        {
            return View();
        }
    }
}