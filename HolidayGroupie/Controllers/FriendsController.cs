using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;
using HolidayGroupie.ViewModels;
using System.Data.Entity;

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
            var friends = _context.Friends.Include(f => f.MembershipType).Include(f => f.UpcomingEvent).ToList();
            
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new NewFriendViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }
        //makes sure only a post request can reach this
        //below is model binding
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            _context.Friends.Add(friend);
            //this is only in memory, so we need to add more
            //to persist changes we call context.saveChanges
            _context.SaveChanges();
            return RedirectToAction("Index", "Friends");
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