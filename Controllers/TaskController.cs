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
        public async Task<TaskListResponse> GetAll()
        {
            TaskEntity obj = new TaskEntity();
            obj.Title = "To Deploy";
            List<TaskEntity> taskList = new List<TaskEntity>();
            taskList.Add(obj);
            TaskListResponse res = new TaskListResponse();
            res.code = "001";
            res.taskList = taskList;
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
    }
}
