using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BergHansenHackathon.Models;
using BergHansenHackathon.ViewModels;
using Microsoft.AspNet.Mvc;
using BergHansenHackathon.Services;

namespace BergHansenHackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISabreService _sabreService;
        private readonly ApplicationDbContext _dbcontext;
        
        public HomeController(ISabreService sabreService, ApplicationDbContext context)
        {
            _dbcontext = context;
            _sabreService = sabreService;
        }
        
        public IActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var meeting = new MeetingRoom();
                meeting.City = "Test City";
                context.MeetingRooms.Add(meeting);
            }
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
        
        [HttpGet("/geolocations")]
        public async Task<GeoList> GetGeoLocations(string query, string category)
        {
            var geolist = await _sabreService.GetGeoAutoComplete(query, category);
            return geolist;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
