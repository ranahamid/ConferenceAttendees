using ConferenceAttendees.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConferenceAttendees.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConferenceAttendees.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClient _client;
        public HomeController(ILogger<HomeController> logger, IClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task< IActionResult> Index()
        {
            //ViewBag["Attendees"] = _client.HttpClient.GetAsync("api/attendees").Result.Content.ReadAsStringAsync().Result;
            ICollection<Gender> genders = await _client.GendersAllAsync();
            try
            {
                ViewBag.Genders = new SelectList(genders, "Id", "Name");
                ViewBag.JobRoles = new SelectList(await _client.JobRolesAllAsync(), "Id", "Name");
                ViewBag.ReferralSources= new SelectList(await _client.ReferralSourcesAllAsync(), "Id", "Name");
            }
            catch (Exception ex)
            {
              
            }

          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Atendee attendee)
        {
            await _client.AtendeesPOSTAsync(attendee);
            return RedirectToAction(nameof(Confirmation));
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
