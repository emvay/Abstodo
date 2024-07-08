using Abstodo.Business.Abstract;
using Abstodo.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Abstodo.WebUI.Controllers
{
    public class CommonController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public CommonController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpGet("Common/GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                List<ProjectModel> projects = _mapper.Map<List<ProjectModel>>(await _projectService.GetAllAsync());
                return Json(new { data = projects });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Couldn't get the Project List\n" + ex.Message });
            }

            //return Json(new { success = false, message = "Update Failed" });
        }
        
    }
}
