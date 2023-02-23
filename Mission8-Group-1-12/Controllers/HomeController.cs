using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Group_1_12.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group_1_12.Controllers
{
    public class HomeController : Controller
    {

        private listEntryContext ListContext { get; set; }

        public HomeController(listEntryContext list)
        {
            ListContext = list;
        }

      
        public IActionResult Index()
        {
            return View();
        }

     
        [HttpGet]
        public IActionResult listEntry()
        {
            ViewBag.Categories = ListContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult listEntry(listEntry le)
        {
            ListContext.Add(le);
            ListContext.SaveChanges();
            return View(le);
        }


    }
}
