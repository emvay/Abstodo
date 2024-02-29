using Abstodo.Business.Abstract;
using Abstodo.Entities.Concrete;
using Abstodo.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Abstodo.WebUI.Controllers
{
    public class TaskController : Controller
    {
        #region dependency injection
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public TaskController(ILogger<TaskController> logger, ITaskService taskService, IProjectService projectService, IMapper mapper)
        {
            _taskService = taskService;
            _projectService = projectService;
            _mapper = mapper;
        }
        #endregion


        public async Task<IActionResult> Index()
        {

            #region working code
            //List<TaskModel> result = _mapper.Map<List<TaskModel>>(await _taskService.GetAllAsync());
            //return View(result);
            #endregion

            return View();
        }

        #region Get All Tasks
        [HttpGet, ActionName("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<TaskModel> tasks = _mapper.Map<List<TaskModel>>(await _taskService.GetAllWithProjectNameAsync());

            if (tasks != null)
            {
                var taskWithProject = tasks.Select(task =>
                {
                    return new
                    {
                        task.ID,
                        task.Description,
                        task.PriorityID,
                        //task.Project.Title,
                        ProjectName= task.Project.Title,
                        StatusName = Enum.GetName(typeof(StatusEnum), task.StatusID)
                    };
                });

                return Json(new { data = taskWithProject });
            }
            return Json(new { success = false });
        }
        #endregion

        #region Get Tasks By Id
        [HttpGet]
        public async Task<IActionResult> GetById(int ID)
        {
            TaskModel task = _mapper.Map<TaskModel>(await _taskService.GetByIdAsync(ID));
            if (task != null)
            {
                return Json(new { data = task });
            }
            return Json(new { success = false });
        }
        #endregion

        #region Add Task JQuery
        [HttpPost, ActionName("Add")]
        public async Task<IActionResult> Add([FromBody] TaskModel taskModel)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                TaskEntity taskEntity = _mapper.Map<TaskEntity>(taskModel);
                taskEntity.UserID = 1;
                await _taskService.InsertAsync(taskEntity);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
                
            //}
            
        }
        #endregion

        #region Update Task JQuery
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TaskModel taskModel)
        {
            try
            {
                TaskEntity taskEntity = _mapper.Map<TaskEntity>(taskModel);
                taskEntity.UserID = 1;
                await _taskService.UpdateAsync(taskEntity);
                return Json(new { success = true, message = "Update Success" });
            }
            catch (Exception)
            {
                return Json(new { success = false,  message = "Update Failed" });
            }

            //return Json(new { success = false, message = "Update Failed" });
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int ID)
        {
            try
            {
                await _taskService.DeleteAsync(ID);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Task not found" });
            }
            return Json(new { success = true, message = "Task deleted!" });
        }

        #region working add func without JQuery

        //public async Task<IActionResult> Add()
        //{
        //    //List<ProjectModel> projects = _mapper.Map<List<ProjectModel>>(await _projectService.GetAllAsync());
        //    //AddTaskViewModel viewModel = new AddTaskViewModel {
        //    //    projectModels = projects

        //    //};
        //    //ViewBag.Projects = projects;
        //    //AddTaskViewModel viewModel = await GetAddTaskViewModelWithProjectList();
        //    return View(await GetAddTaskViewModelWithProjectList());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(AddTaskViewModel viewModel)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    // Save the TaskEntity to the database using Entity Framework
        //    TaskEntity taskEntity = _mapper.Map<TaskEntity>(viewModel.taskModel);
        //    taskEntity.UserID = 1;
        //    await _taskService.InsertAsync(taskEntity);

        //    // Redirect to a different action after successful submission
        //    //return RedirectToAction("Index", "Task");
        //    //}

        //    // If ModelState is not valid, return to the form with the same ViewModel
        //    return View(await GetAddTaskViewModelWithProjectList());
        //}
        #endregion

        #region working remove func without JQuery
        //[HttpPost, ActionName("Remove")]
        //public async Task<JsonResult> Remove(int taskID)
        //{
        //    try
        //    {
        //        await _taskService.DeleteAsync(taskID);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { success = false, message = "Task not found" });
        //    }
        //    return Json(new { success = true, message = "Task has been deleted" });
        //}
        #endregion

        #region Update func without JQuery
        //[HttpPost]
        //public async Task<IActionResult> Update(TaskModel taskModel)
        //{
        //    return View();
        //}
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<AddTaskViewModel> GetAddTaskViewModelWithProjectList()
        {
            List<ProjectModel> projects = _mapper.Map<List<ProjectModel>>(await _projectService.GetAllAsync());

            AddTaskViewModel viewModel = new AddTaskViewModel
            {
                projectModels = projects

            };
            return viewModel;
        }
    }
}
