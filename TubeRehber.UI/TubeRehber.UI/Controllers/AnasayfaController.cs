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
    public class AnasayfaController : Controller
    {
        ChannelService _channelService;
        CommentService _commentService;
        MemberService _memberService;

        public AnasayfaController()
        {
            _channelService = new ChannelService();
            _commentService = new CommentService();
            _memberService = new MemberService();
        }
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View(_channelService.GetActive());
        }

        public ActionResult List(string ChannelName)
        {
            List<Comment> Comments = _commentService.GetActive();

            Dictionary<string, string> comments = new Dictionary<string, string>();
            TubeRehber.Model.Entities.Channel channel = _channelService.GetChannelByChannelName(ChannelName);

            string ChannelID = channel.ID.ToString();


            foreach (var item in Comments)
            {
                if (item.ChannelID.ToString() == ChannelID)
                {
                    TubeRehber.Model.Entities.Member member = _memberService.GetByID(item.MemberID);


                    comments.Add(item.comment, member.UserName);
                }
            }
            TempData["Yorumlar"] = comments;

            return View();
        }
    }
}