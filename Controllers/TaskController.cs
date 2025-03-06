using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        public TaskController( UserManager<AppUser> userManager, ITaskService service)
        {
            _userManager = userManager;
            _taskService = service;
        }

        [HttpGet]
        [Route("GetAllTask")]
        public async Task<ListResponse<TaskEntity>> GetAll()
        {
          
            var list = await _taskService.GetAllAssignTaskAsync();
            ListResponse<TaskEntity> res = new ListResponse<TaskEntity>();
            res.code = "001";
            res.ResponseList = list;
            return res;
        }
        [HttpPost("deleteTask")]
        public async Task<ResponseMessage> DeleteTask(TaskEntity taskentity)
        {
            await _taskService.DeleteAsync(taskentity.Id);
            ResponseMessage res = new ResponseMessage();
            res.code = "001";
            res.description = "Task deleted successful!";
            return res;
        }
        [HttpPost]
        [Route("updateTask")]
        public async Task<ResponseMessage> UpdateAsync(TaskEntity taskentity)
        {
            await _taskService.UpdateAsync(taskentity);
            ResponseMessage res = new ResponseMessage();
            res.code = "001";
            res.description = "Task updated successful!";
            return res;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _taskService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPost]
        [Route("createTask")]
        public async Task<ResponseMessage> createTask(TaskEntity taskentity)
        {
            await _taskService.AddAsync(taskentity);
            ResponseMessage res = new ResponseMessage();
            res.code = "001";
            res.description = "Task created successful!";
            return res;

        }



        [HttpPost]
        [Route("assignTask")]
        public async Task<ResponseMessage> assignTask(AssignTaskEntity taskentity)
        {
            await _taskService.AssignTaskAsync(taskentity);
            ResponseMessage res = new ResponseMessage();
            res.code = "001";
            res.description = "Assigned Task successful!";
            return res;

        }
    }
}
