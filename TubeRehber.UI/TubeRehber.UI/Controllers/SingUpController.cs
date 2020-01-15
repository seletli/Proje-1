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
    public class SingUpController : Controller
    {
        MemberService _memberService;
        public SingUpController()
        {
            _memberService = new MemberService();
        }
        [HttpPost]
        public ActionResult Add(Member data)
        {
            _memberService.Add(data);
            data.Status = Core.Entity.Enum.Status.Active;
            data.Role = Model.Entities.Role.Member;
            
            _memberService.Save();

            return RedirectToAction("Index", "Home", new { area = "Member" });
        }
         
        // GET: SingUp
        public ActionResult Index()
        {
            return View();
        }
    }
}