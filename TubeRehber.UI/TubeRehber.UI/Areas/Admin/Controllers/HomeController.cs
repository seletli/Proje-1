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
   
    public class HomeController : BaseController
    {


        

        public ActionResult Index()
        {
            
            
            return View();
        }
    }
}