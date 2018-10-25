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
        public ApplicationDbContext _context;

        public FriendsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Friends
        public ActionResult Index()
        {
            //when this line is executed thi is deffered
            //execution
            //
            var friends = _context.Friends.ToList();

            return View(friends);
        }

        public ActionResult Details(int id)
        {
            var friend = _context.Friends.SingleOrDefault(f => f.Id == id);

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