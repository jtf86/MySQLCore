using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySQLCore.Models;
using System;

namespace MySQLCore.Controllers
{
    public class HomeController : Controller
    {

// HOME AND MENU ROUTES
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("/tasks")]
        public ActionResult Tasks()
        {
            List<Task> allTasks = Task.GetAll();
            return View(allTasks);
        }
        [HttpGet("/categories")]
        public ActionResult Categories()
        {
            List<Category> allCategories = Category.GetAll();
            return View(allCategories);
        }

//NEW TASK
        [HttpGet("/tasks/new")]
        public ActionResult TaskForm()
        {
            return View();
        }
        [HttpPost("/tasks/new")]
        public ActionResult TaskCreate()
        {
            Task newTask = new Task(Request.Form["task-description"]);
            newTask.Save();
            return View("Success");
        }

//NEW CATEGORY
        [HttpGet("/categories/new")]
        public ActionResult CategoryForm()
        {
            return View();
        }
        [HttpPost("/categories/new")]
        public ActionResult CategoryCreate()
        {
            Category newCategory = new Category(Request.Form["category-name"]);
            newCategory.Save();
            return View("Success");
        }

//ONE TASK
        [HttpGet("/tasks/{id}")]
        public ActionResult TaskDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Task selectedTask = Task.Find(id);
            List<Category> TaskCategories = selectedTask.GetCategories();
            List<Category> AllCategories = Category.GetAll();
            model.Add("task", selectedTask);
            model.Add("taskCategories", TaskCategories);
            model.Add("allCategories", AllCategories);
            return View( model);

        }

//ONE CATEGORY
        [HttpGet("/categories/{id}")]
        public ActionResult CategoryDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category SelectedCategory = Category.Find(id);
            List<Task> CategoryTasks = SelectedCategory.GetTasks();
            List<Task> AllTasks = Task.GetAll();
            model.Add("category", SelectedCategory);
            model.Add("categoryTasks", CategoryTasks);
            model.Add("allTasks", AllTasks);
            return View(model);
        }

//ADD CATEGORY TO TASK
        [HttpPost("task/add_category")]
        public ActionResult TaskAddCategory()
        {
            Category category = Category.Find(Int32.Parse(Request.Form["category-id"]));
            Task task = Task.Find(Int32.Parse(Request.Form["task-id"]));
            task.AddCategory(category);
            return View("Success");
        }

//ADD TASK TO CATEGORY
        [HttpPost("category/add_task")]
        public ActionResult CategoryAddTask()
        {
            Category category = Category.Find(Int32.Parse(Request.Form["category-id"]));
            Task task = Task.Find(Int32.Parse(Request.Form["task-id"]));
            category.AddTask(task);
            return View("Success");
        }
    }
}
