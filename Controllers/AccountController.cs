
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AppUser> _siginManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService mailService;
        public AccountController(IMailService mailService,ILogger<AccountController> logger, SignInManager<AppUser> siginManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _siginManager = siginManager;
            _userManager = userManager;
            this.mailService = mailService;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ResponseMessage> Register(AppUser user)
        {
            ResponseMessage res = new ResponseMessage();
            try
            {
                var result = await _userManager.CreateAsync(user, user.Password);

                if (result.Succeeded)
                {
                    res.code = "001";
                    res.description = "Registration successful!";
                }
                else
                {
                    res.code = "002";
                    foreach (var error in result.Errors)
                    {
                        res.description = error.Description;
                    }

                }
            }
            catch (Exception e)
            {
                res.code = "002";
                res.description = e.Message;
            }
            return res;

        }

        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{

        //    var user = await _userManager.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }

        //    var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    return View();
        //}

       
        [HttpPost]
        [Route("sendEmail")]
        public async Task<ResponseMessage> SendEmail(MailRequest user)
        {
            ResponseMessage res = new ResponseMessage();
            try
            {
                var rs = await mailService.SendEmailAsync(user.ToEmail);
                if (rs)
                {
                    res.code = "001";
                    res.description = "Email sent successful!";
                }
                else
                {
                    res.code = "002";
                    res.description = "Email sent fail!";
                }
                
            }
            catch (Exception e)
            {
                res. code= "002";
                res.description = e.Message;
            }
            return res;

        }




    }
}
