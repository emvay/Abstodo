using Abstodo.Business.Abstract;
using Abstodo.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Abstodo.WebUI.Controllers
{
	public class TaskController : Controller
	{
		private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;
        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
		{
			_logger = logger;
			_taskService = taskService;

        }

		public IActionResult Index()
		{
			_taskService.GetAll();
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
	}
}
