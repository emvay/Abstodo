using Abstodo.Business.Abstract;
using Abstodo.Entities.Concrete;
using Abstodo.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Abstodo.WebUI.Controllers
{
    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public TaskController(ILogger<TaskController> logger, ITaskService taskService, IProjectService projectService, IMapper mapper)
        {
            _taskService = taskService;
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //tasks = new List<TaskEntity>();
            //List<TaskEntity> tasks = await _taskService.GetAllAsync();
            List<TaskModel> result = _mapper.Map<List<TaskModel>>(await _taskService.GetAllAsync());
            return View(result);
        }

        public async Task<IActionResult> Add()
        {
            //List<ProjectModel> projects = _mapper.Map<List<ProjectModel>>(await _projectService.GetAllAsync());
            //AddTaskViewModel viewModel = new AddTaskViewModel {
            //    projectModels = projects

            //};
            //ViewBag.Projects = projects;
            //AddTaskViewModel viewModel = await GetAddTaskViewModelWithProjectList();
            return View(await GetAddTaskViewModelWithProjectList());
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTaskViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            // Save the TaskEntity to the database using Entity Framework
            TaskEntity taskEntity = _mapper.Map<TaskEntity>(viewModel.taskModel);
            taskEntity.UserID = 1;
            await _taskService.InsertAsync(taskEntity);

            // Redirect to a different action after successful submission
            //return RedirectToAction("Index", "Task");
            //}

            // If ModelState is not valid, return to the form with the same ViewModel
            return View(await GetAddTaskViewModelWithProjectList());
        }

        //[HttpPost, ActionName("Remove")]
        public async Task<JsonResult> Remove(int taskID)
        {
            await _taskService.DeleteAsync(taskID);
            return Json(new { success = false, message = "Task not found" });
        }
        [HttpPost]
        public async Task<IActionResult> Update()
        {
            return View();
        }

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
