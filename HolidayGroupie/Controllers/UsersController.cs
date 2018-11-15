using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolidayGroupie.Models;

namespace HolidayGroupie.Controllers
{
    public class UsersController : Controller
    {
        public ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Create(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", newUser);
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index", "Events");

        }
    }
}