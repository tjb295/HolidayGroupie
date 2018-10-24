using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;

namespace HolidayGroupie.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            var myEvents = GetEvents();

            return View(myEvents);
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