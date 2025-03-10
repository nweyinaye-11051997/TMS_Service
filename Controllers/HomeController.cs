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
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomeController(UserManager<AppUser> userManager, IHomeService service)
        {
            _homeService = service;
        }
        [HttpGet]
        [Route("GetAllCountTask")]
        public async Task<CountRes> GetAll()
        {

            var count = await _homeService.GetTotalCount();
            var res = new CountRes
            {
                code = "001",
                description = "Task count  fetched successfully",
                count = count
            };
            return res;
        }
    }
}
