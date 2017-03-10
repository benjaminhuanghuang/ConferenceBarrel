using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConferenceBarrel.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceBarrel.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CreateConference()
        {
            var conference = new Conference
            {
                Name = "First Conference",
                TicketPrice = 250.00m
            };
            ctx.Conferences.Add(conference);
            ctx.SaveChanges();

            var sessionTitles = new List<string>{
                ".NET Core", "ASP.NET Core", "Entity Framework Core"
            };

            foreach(var title in sessionTitles)
            {
                var session  = new Session{
                    Title = title,
                    Conference = conference
                };
                ctx.Session.Add(session);
                ctx.SaveChanges();
            }
            return RedirectToAction("ViewConference");
        }

        public IActionResult ViewConference()
        {
            // EF does not early load related collections
            // var conference = ctx.Conferences.First();  ! Error !
            var conference = ctx.Conferences.Include(c=>c.Sessions).First();
            return View(conference);
        }
    }
}
