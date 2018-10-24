using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;

namespace HolidayGroupie.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Index()
        {
            var friends = GetFriends();
            return View(friends);
        }

        public ActionResult Details(int id)
        {
            var friend = GetFriends().SingleOrDefault(f => f.Id == id);

            if (friend == null)
            {
                return HttpNotFound();
            }

            return View(friend);
        }

        public IEnumerable<Friend> GetFriends()
        {
            return new List<Friend>
            {
                new Friend {Id = 1, Name = "Sean"},
                new Friend {Id = 2, Name = "Kairey"}
            };
        }
    }
}