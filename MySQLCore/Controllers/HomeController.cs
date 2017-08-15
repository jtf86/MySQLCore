using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySQLCore.Models;

namespace MySQLCore.Controllers
{
    public class HomeController : Controller
    {

// HOME AND CREATE ROUTES

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Task> allTasks = Task.GetAll();
            return View(allTasks);
        }

        [HttpPost("/create")]
        public ActionResult CreateTask()
        {
            Task newTask = new Task(Request.Form["taskname"], 1);
            newTask.Save();
            List<Task> allTasks = Task.GetAll();
            return View("Index", allTasks);
        }

        [HttpGet("/tasks/{id}/edit")]
        public ActionResult EditTask(int id)
        {
            Task thisTask = Task.Find(id);
            return View(thisTask);
        }

        [HttpPost("/tasks/{id}/edit")]
        public ActionResult EditTaskConfirm(int id)
        {
            Task thisTask = Task.Find(id);
            thisTask.UpdateDescription(Request.Form["newname"]);
            return RedirectToAction("Index");
        }


    }
}
