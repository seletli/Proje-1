﻿using TubeRehber.Model.Entities;
using TubeRehber.Service.Concrete;
using TubeRehber.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TubeRehber.UI.Controllers
{
    public class ModaController : Controller
    {
        ChannelService _channelService;
        CommentService _commentService;
        MemberService _memberService;
        CategoryService _categoryService;

        public ModaController()
        {
            _channelService = new ChannelService();
            _commentService = new CommentService();
            _memberService = new MemberService();
            _categoryService = new CategoryService();
        }
        
        public ActionResult Index()
        {
            List<Channel> Channels = _channelService.GetActive();

            Dictionary<string, string> ChannelLinks = new Dictionary<string, string>();

            TubeRehber.Model.Entities.Category category = _categoryService.GetCategoryByCategoryName("Moda");

            foreach (var item in Channels)
            {
                if (item.CategoryID.ToString() == (category.ID).ToString())
                {
                    ChannelLinks.Add(item.ChannelName, item.ChannelLink);
                }
            }

            TempData["FashionChannelLinks"] = ChannelLinks;

            return View();
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