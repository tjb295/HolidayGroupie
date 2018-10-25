using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;
using System.Data.Entity;

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

            if (myEvent == null)
            {
                return HttpNotFound();
            }

            return View(myEvent);
        }

        public ActionResult EventForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Event myEvent)
        {
       

            if (myEvent.Id == 0)
            {
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