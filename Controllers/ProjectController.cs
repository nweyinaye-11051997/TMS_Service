using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceImpl;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.Controllers
{
    
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        { 
            this._projectService = projectService;
        }
        [HttpPost]
        [Route("createProject")]
        public async Task<ResponseMessage> createProject(ProjectEntity entity)
        {
            await _projectService.AddAsync(entity);
            var res = new ResponseMessage
            {
                code = "001",
                description = "Project created successful!",
            };
            return res;

        }


        [HttpGet]
        [Route("GetAllProject")]
        public async Task<ListResponse<ProjectEntity>> GetAllProject()
        {

            var list = await _projectService.GetAllAsync();
            var res = new ListResponse<ProjectEntity>
            {
                code = "001",
                description = "Project  fetched successfully",
                ResponseList = list
            };
            return res;
        }
    }
}
