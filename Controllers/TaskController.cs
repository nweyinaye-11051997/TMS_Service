using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var res = new ListResponse<TaskEntity>
            {
                code = "001",
                description = "Task count  fetched successfully",
                ResponseList = list
            };
            return res;
        }
        [HttpPost("deleteTask")]
        public async Task<ResponseMessage> DeleteTask(TaskEntity taskentity)
        {
            await _taskService.DeleteAsync(taskentity.Id);
            var res = new ResponseMessage
            {
                code = "001",
                description = "Task deleted successful!",
            };
            return res;
        }
        [HttpPost]
        [Route("updateTask")]
        public async Task<ResponseMessage> UpdateAsync(TaskEntity taskentity)
        {
            await _taskService.UpdateAsync(taskentity);
            var res = new ResponseMessage
            {
                code = "001",
                description = "Task updated successful!",
            };
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
            var res = new ResponseMessage
            {
                code = "001",
                description = "Task created successful!",
            };
            return res;

        }
    }
}
