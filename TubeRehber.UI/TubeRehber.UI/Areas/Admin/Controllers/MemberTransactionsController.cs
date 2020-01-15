using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TubeRehber.UI.Areas.Admin.Controllers
{
    public class MemberTransactionsController : BaseController
    {
        new MemberService _memberService;
        

        public MemberTransactionsController()
        {
            _memberService = new MemberService();
            
        }

        
           


        

        [HttpGet]
        public ActionResult Index()
        {

            return View(_memberService.GetActive());
        }


        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("Index");
            TubeRehber.Model.Entities.Member guncellenecek = _memberService.GetByID((Guid)id);


            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(TubeRehber.Model.Entities.Member data)
        {


            TubeRehber.Model.Entities.Member guncellenecek = _memberService.GetByID(data.ID);


            data.CreatedBy = userID;
            guncellenecek.Name = data.Name;
            guncellenecek.SurName = data.SurName;
            guncellenecek.UserName = data.UserName;
            guncellenecek.BirthDate = data.BirthDate;
            guncellenecek.Email = data.Email;
            guncellenecek.Role = data.Role;
            guncellenecek.Password = data.Password;
            guncellenecek.Status = data.Status;






            _memberService.Update(guncellenecek);
            _memberService.Save();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Add()
        {

            return View(_memberService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(TubeRehber.Model.Entities.Member data)
        {

            data.CreatedBy = userID;
            data.Status = TubeRehber.Core.Entity.Enum.Status.Active;
            _memberService.Add(data);
            _memberService.Save();

           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {

           

            return View(_memberService.Get());
        }



        [HttpGet]
        public ActionResult Deletee(Guid ID)
        {
            
            _memberService.Delete(ID);
            _memberService.Save();
            return RedirectToAction("Delete");

        }


    }
}