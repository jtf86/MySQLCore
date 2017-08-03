using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySQLCore.Models;

namespace MySQLCore.Controllers
{
    public class HomeController : Controller
    {

// HOME AND VIEW ALL ROUTES

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Task> allTasks = Task.GetAll();
            return View(allTasks);
        }

        [HttpPost("/create")]
        public ActionResult CreateTask()
        {
            Task newTask = new Task(Request.Form["taskname"]);
            newTask.Save();
            List<Task> allTasks = Task.GetAll();
            return View("Index", allTasks);
        }

    }
}
