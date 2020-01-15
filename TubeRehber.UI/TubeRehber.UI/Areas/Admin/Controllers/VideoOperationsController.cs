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
    public class VideoOperationsController : BaseController
    {
        String CategoryName;
        ChannelService _channelService;
        CategoryService _categoryService;

        public VideoOperationsController()
        {
            
            _channelService = new ChannelService();
            _categoryService = new CategoryService();
        }


        // GET: Admin/VideoOperations
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TubeRehber.Model.Entities.Channel data,TubeRehber.Model.Entities.Category data2)
        {


            CategoryName = data2.CategoryName;
           

            data.Status = TubeRehber.Core.Entity.Enum.Status.Active;
            TubeRehber.Model.Entities.Category category=_categoryService.GetCategoryByCategoryName(CategoryName);
            data.CategoryID = category.ID;
            
            

           
           
            _channelService.Add(data);
            _channelService.Save();
           
           



            return RedirectToAction("Index");
        }

       public ActionResult Listele()
        {
            return View(_channelService.GetActive());
        }
        
        public ActionResult Delete(Guid ID)
        {
            _channelService.Delete(ID);
            _channelService.Save();
            return RedirectToAction("Listele");
        }

       
    }
}