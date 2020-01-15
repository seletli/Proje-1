﻿using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TubeRehber.UI.Areas.Member.Controllers
{
    public class HomeController : BaseController
    {
        ChannelService _channelService;
        CommentService _commentService;
        new readonly MemberService _memberService;

        public HomeController()
        {
            _channelService = new ChannelService();
            _commentService = new CommentService();
            _memberService = new MemberService();
        }

        // GET: Member/Home
        public ActionResult Index()
        {
            return View(_channelService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(TubeRehber.Model.Entities.Comment data, string ChannelName)
        {
            if (data.comment != null)
            {
                TubeRehber.Model.Entities.Member currentUser = _memberService.GetuserByUserName(HttpContext.User.Identity.Name);
                data.MemberID = currentUser.ID;
                TubeRehber.Model.Entities.Channel channel = _channelService.GetChannelByChannelName(ChannelName);
                data.ChannelID = channel.ID;


                _commentService.Add(data);
                _commentService.Save();
            }
            return RedirectToAction("Index");
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