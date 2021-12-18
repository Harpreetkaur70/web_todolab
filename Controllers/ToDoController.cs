using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAsp.NetCore.ViewModel;

namespace ToDoListAsp.NetCore.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public ToDoController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // Todo view
        public IActionResult Index()
        {
            return View();
        }

        //Save New Task
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel task)
        {
            try
            {
                if (!string.IsNullOrEmpty(task.Title))
                {
                    var newTask = new Models.Task();
                    newTask.Title = task.Title;
                    newTask.IsComplete=false;
                    _Context.Tasks.Add(newTask);
                    await _Context.SaveChangesAsync();
                    return Json(new { status = "success", message = "Saved Successfully" });
                }
                return Json(new { status = "error", message = "Title must not be empty" });
            }
            catch(Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }

        //Update task as Complete
        [HttpPost]
        public IActionResult MarkAsCompleteTask(int id)
        {
            if (id > 0)
            {
                var GetTask = _Context.Tasks.Where(a => a.TaskID == id).FirstOrDefault();
                if (GetTask != null)
                {
                    GetTask.IsComplete = true;
                    _Context.SaveChanges();
                }
                return Json(new { status = "success", message = "Updated Successfully" });
            }
            return Json(new { status = "error", message = "Invalid Task" });

        }

        //Get All InComplete Todo list
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var ObjTask=new Models.Task();
            var TaskList = new List<Models.Task>(); 
            var GetTask = _Context.Tasks.Where(x => x.IsComplete == false).ToList();
            
            foreach (var item in GetTask)
            {
                ObjTask = new Models.Task();
                ObjTask.TaskID = item.TaskID;
                ObjTask.Title = item.Title;
                ObjTask.IsComplete = item.IsComplete;
                TaskList.Add(ObjTask);
            }
                return Json(new { status = "success", data = TaskList });
           
        }
    }
}
