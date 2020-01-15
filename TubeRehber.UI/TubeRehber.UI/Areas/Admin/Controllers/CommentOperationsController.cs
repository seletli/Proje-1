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
    public class CommentOperationsController : BaseController
    {
        CommentService _commentService;
        ChannelService _channelService;
        new readonly MemberService _memberService;

        public CommentOperationsController()
        {
            _commentService = new CommentService();
            _channelService = new ChannelService();
            _memberService = new MemberService();
            
        }
        
        // GET: Admin/CommentOperations
        public ActionResult Index()
        {
          
            
            return View(_commentService.GetActive());
        }
     
        public ActionResult Delete(Guid ID)
        {
            _commentService.Delete(ID);
            _commentService.Save();
            return RedirectToAction("Index");
        }
    }
}