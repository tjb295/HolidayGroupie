using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;
using System.Data.Entity;
using HolidayGroupie.ViewModels;

namespace HolidayGroupie.Controllers
{
    public class EventsController : Controller
    {
        public ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Events
        public ActionResult Index()
        {
            var myEvents = _context.Events.ToList();

            return View(myEvents);
        }

        public ActionResult Details(int id)
        {
            var myEvent = _context.Events.Include(e => e.OrganizerId).SingleOrDefault(e => e.Id == id);
            var itemsInEvent = _context.Items.Join(_context.Events,
                                i => i.EventId,
                                e => e.Id,
                                (i, e) => new { i, e })
                                .Where(ie => ie.e.Id == id && ie.i.EventId == id)
                                .Select(ie => ie.i).ToList();

            var eventViewModel = new EventItemViewModel
            {
                Event = myEvent,
                Item = new Item(),
                Items = itemsInEvent,
                Friends = myEvent.Attendees,
                SearchableFriends = _context.Friends.ToList()

            };

            if (myEvent == null)
            {
                return HttpNotFound();
            }

            return View(eventViewModel);
        }

        public ActionResult EventForm()
        {
            Event myEvent = new Event();
            return View(myEvent);
        }


        [HttpPost]
        public ActionResult Save(Event myEvent)
        {
            if(!ModelState.IsValid)
            {
                return View("EventForm", myEvent);
            }

            myEvent.Attendees = new List<Friend>();
            myEvent.Items = new List<Item>();

            if (myEvent.Id == 0)
            {
                myEvent.OrganizerId = _context.Friends.Find(1);

                _context.Events.Add(myEvent);
            }
            else
            {
                var eventInDb = _context.Events.Single(f => f.Id == myEvent.Id);

                //controllers have a method call try update model
                //TryUpdateModel(friendInDb);
                //but this can open up security holes in app
                //do not blindly read request data
                eventInDb.Name = myEvent.Name;
                eventInDb.Description = myEvent.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Events");
        }

        private IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {
               new Event { Id = 1, Name = "Halloween Party", Date = new DateTime(2018, 10,31,8,30,52)},
                new Event { Id = 2, Name = "Seans Birthday", Date = new DateTime(2018, 11, 1, 0,0,0)}
            };
        }
    }
}