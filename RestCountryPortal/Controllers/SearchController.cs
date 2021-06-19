using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCountryPortal.Models;
using RestCountryPortal.Services;

namespace RestCountryPortal.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string NationName, int Offset, int Limit, string SortDir)
        {
            // == Check Parameter ==
            string nationName = NationName;
            int offset = Offset;
            int limit = Limit;
            string sortDir = SortDir;
           

            List<CountryDataModel> results = new SearchService().Search(nationName, offset, limit, sortDir);

            ViewBag.Result = results;

            return View(results);
        }

    }
}