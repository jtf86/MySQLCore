using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySQLCore.Models;
using System;

namespace MySQLCore.Controllers
{
    public class HomeController : Controller
    {

// HOME AND CREATE ROUTES

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Task> allTasks = Task.GetAll();
            List<Category> allCategories = Category.GetAll();
            Dictionary<string, object> model = new Dictionary<string, object>() {};
            model.Add("tasks", allTasks);
            model.Add("categories", allCategories);
            return View(model);
        }

        [HttpPost("/tasks/add")]
        public ActionResult CreateTask()
        {
            Task newTask = new Task(Request.Form["taskname"], Int32.Parse(Request.Form["taskcategory"]));
            newTask.Save();
            return RedirectToAction("Index");
        }

        [HttpPost("/category/add")]
        public ActionResult CreateCategory()
        {
            Category newCategory = new Category(Request.Form["categoryname"]);
            newCategory.Save();
            return RedirectToAction("Index");
        }


        //EDIT ROUTES
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

        //DELETE ROUTES
        [HttpGet("/tasks/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Task task = Task.Find(id);
            return View(task);
        }

        [HttpPost("/tasks/{id}/delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task thisTask = Task.Find(id);
            thisTask.Delete();
            return View("DeleteConfirmed", thisTask);
        }




    }
}
