using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return View("listEntry", new listEntry());
        }

        [HttpPost]
        public IActionResult listEntry(listEntry le)
        {
            ListContext.Add(le);
            ListContext.SaveChanges();
            ViewBag.Categories = ListContext.Categories.ToList();
            var allTasks = ListContext.listEntry
                .Where(x => x.Completed == false)
                .OrderBy(x => x.DueDate)
                .Include(x => x.Category)
                .ToList();
            return View("ToDoList", allTasks);
        }

        [HttpGet]
        public IActionResult ToDoList()
        {
            var allTasks = ListContext.listEntry
                .Where(x => x.Completed == false)
                .OrderBy(x => x.DueDate)
                .Include(x => x.Category)
                .ToList();

            return View(allTasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            ViewBag.Categories = ListContext.Categories.ToList();

            var task = ListContext.listEntry.Single(x => x.TaskID == taskId);
            return View("listEntry", task);
        }

        [HttpPost]
        public IActionResult Edit(listEntry updatedEntry)
        {
            ListContext.Update(updatedEntry);
            ListContext.SaveChanges();
            //ViewBag.Categories = ListContext.Categories.ToList();

            return RedirectToAction("ToDoList");
        }

        [HttpGet]
        public IActionResult Delete(int taskId)
        {
            var task = ListContext.listEntry.Single(x => x.TaskID == taskId);

            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(listEntry le)
        {
            ListContext.listEntry.Remove(le);
            ListContext.SaveChanges();

            return RedirectToAction("ToDoList");
        }

        public IActionResult Quadrant()
        {
            var allTasks = ListContext.listEntry
                .Where(x => x.Completed == false)
                .OrderBy(x => x.DueDate)
                .Include(x => x.Category)
                .ToList();

            return View(allTasks);
        }
    }
}
