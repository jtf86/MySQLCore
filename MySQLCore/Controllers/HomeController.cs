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
            return RedirectToAction("Index");
        }

        [HttpGet("/delete/{id}")]
        public ActionResult Delete(int id)
        {
            Task thisTask = Task.Find(id);
            return View("Delete", thisTask);
        }

        [HttpPost("/delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
