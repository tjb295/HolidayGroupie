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
                Friend = new Friend(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }
        //makes sure only a post request can reach this
        //below is model binding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Friend friend)
        {
            //we1 can use model state property to get validation data
            if (!ModelState.IsValid)
            {
                //redirect user back to form if not
                //3 steps for valiation
                var viewModel = new NewFriendViewModel
                {
                    Friend = friend,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("New", viewModel);
            }

            if (friend.Id == 0)
            {
                _context.Friends.Add(friend);
            }
            else
            {
                var friendInDb = _context.Friends.Single(f => f.Id == friend.Id);

                //controllers have a method call try update model
                //TryUpdateModel(friendInDb);
                //but this can open up security holes in app
                //do not blindly read request data
                friendInDb.Name = friend.Name;
                friendInDb.LastName = friend.LastName;
                friendInDb.Email = friend.Email;
                //could also use mapper
                //Mapper.map(friend, friendInDb)
            }
            
            //this is only in memory, so we need to add more
            //to persist changes we call context.saveChanges
            _context.SaveChanges();
            return RedirectToAction("Index", "Friends");
        }

        public ActionResult Delete(int id)
        {
            var friend = _context.Friends.SingleOrDefault(f => f.Id == id);
            _context.Friends.Remove(friend);
            _context.SaveChanges();

            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var friend = _context.Friends.SingleOrDefault(f => f.Id == id);

            if (friend == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewFriendViewModel
            {
                Friend = friend,
                MembershipTypes = _context.MembershipType.ToList()
            };

            //specify view name to take to
            return View("New", viewModel);
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