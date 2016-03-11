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
        
        public HomeController(ISabreService sabreService)
        {
            _sabreService = sabreService;
        }
        
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
