using Abstodo.Business.Abstract;
using Abstodo.Business.Common;
using Abstodo.Entities.Concrete;
using Abstodo.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Abstodo.WebUI.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        #region dependency injection
        private readonly ITaskService _taskService;
        private readonly ICommonService _commonService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IProjectService projectService, ICommonService commonService, IMapper mapper)
        {
            _commonService = commonService;
            _taskService = taskService;
            _projectService = projectService;
            _mapper = mapper;
        }
        #endregion


        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet("Task/LoadIndex")]
        public async Task<IActionResult> LoadIndex()
        {
            try
            {
                int IDClaim = await _commonService.GetUserIDFromClaims((ClaimsIdentity)User.Identity);

                int CompletedTaskCount = await _taskService.GetAllCompletedTaskCount(IDClaim);
                int OpenTaskCount = await _taskService.GetAllOpenTaskCount(IDClaim);
                int CompletedProjectCount = await _projectService.GetAllCompletedProjectCount(IDClaim);
                int OpenProjectCount = await _projectService.GetAllOpenProjectCount(IDClaim);

                IndexModel indexModel = new IndexModel
                {
                    CompletedTaskCount = CompletedTaskCount,
                    OpenTaskCount = OpenTaskCount,
                    CompletedProjectCount = CompletedProjectCount,
                    OpenProjectCount = OpenProjectCount
                };
                return Json(new { data = indexModel });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Operation failed!\n" + ex.Message });
            }

            


           
        }
        [HttpGet("Task/List/{projectID}")]
        public async Task<IActionResult> List([FromRoute] int projectID)
        {
            ViewBag.ProjectID = projectID;
            return View();
        }

        #region Get All Tasks
        //[HttpGet, ActionName("GetAll")]
        [HttpGet("Task/GetAll/{projectID}")]
        public async Task<IActionResult> GetAll([FromRoute] int projectID)
        {
            List<TaskModel> tasks = _mapper.Map<List<TaskModel>>(await _taskService.GetTasksByProjectID(projectID));

            if (tasks != null)
            {
                var taskWithProject = tasks.Select(task =>
                {
                    return new
                    {
                        task.ID,
                        task.Description,
                        task.PriorityID,
                        DueDate=task.DueDate.Value.ToString("yyyy-MM-dd hh:mm"),
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
            var identity = (ClaimsIdentity)User.Identity;
            int IDClaim= Convert.ToInt32(identity.Claims.FirstOrDefault(t => t.Type == "ID").Value);
            //if (ModelState.IsValid)
            try
            {
                TaskEntity taskEntity = _mapper.Map<TaskEntity>(taskModel);
                taskEntity.UserID = IDClaim;
                await _taskService.InsertAsync(taskEntity);
                return Json(new { success = true, message = "Task Added!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Task add failed!\n" + ex.Message });
            }
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
            catch (Exception ex)
            {
                return Json(new { success = false,  message = "Update Failed\n" + ex.Message });
            }

            //return Json(new { success = false, message = "Update Failed" });
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CompleteTask(int ID)
        {
            try
            {
                await _taskService.CompleteTaskAsync(ID);
                return Json(new { success = true, message = "Task completed!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Task not found\n" + ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int ID)
        {
            try
            {
                await _taskService.DeleteAsync(ID);
                return Json(new { success = true, message = "Task deleted!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Task not found\n" + ex.Message });
            }
            
        }
        [HttpGet]
        public JsonResult GetPriorityNames()
        {
            // Get the enum values (consider converting to a suitable format for JSON)
            var priorityNames = Enum.GetNames(typeof(PriorityEnum));
            return Json(priorityNames);
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
