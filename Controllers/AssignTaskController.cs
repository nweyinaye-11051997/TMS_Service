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
    public class AssignTaskController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IAssignTaskService _taskService;
        public AssignTaskController(UserManager<AppUser> userManager, IAssignTaskService service)
        {
            _userManager = userManager;
            _taskService = service;
        }
        [HttpPost]
        [Route("updateAssignTask")]
        public async Task<ResponseMessage> updateAssignTask(AssignTaskEntity taskentity)
        {
            try { 
            await _taskService.UpdateAssignTaskAsync(taskentity);
            var res = new ResponseMessage
            {
                code = "001",
                description = "Assigned Task updated  successful!",
            };
            return res;
        }catch(Exception e)
            {
                var res = new ResponseMessage
                {
                    code = "005",
                    description = e.Message,
                };
                return res;
            }
}

        [HttpPost]
        [Route("assignTask")]
        public async Task<ResponseMessage> assignTask(AssignTaskEntity taskentity)
        {
            try
            {
                await _taskService.AddAssignTaskAsync(taskentity, taskentity.TaskID, taskentity.MemberID);
                var res = new ResponseMessage
                {
                    code = "001",
                    description = "Assigned Task successful!",
                };
                return res;
            }catch(Exception e)
            {
                var res = new ResponseMessage
                {
                    code = "005",
                    description = e.Message,
                };
                return res;
            }          
           

        }
    }
}
