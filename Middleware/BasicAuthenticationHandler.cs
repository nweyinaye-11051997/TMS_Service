using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Identity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Middleware
{
    public class BasicAuthenticationHandler //: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //private readonly LearndataContext context;
        //private readonly SignInManager<AppUser> _siginManager;
        //public BasicAuthenticationHandler(SignInManager<AppUser> siginManager,IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LearndataContext context) : base(options, logger, encoder, clock)
        //{
        //    this.context = context;
        //    _siginManager = siginManager;
        //}

        //protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        //{
        //    if (!Request.Headers.ContainsKey("Authorization"))
        //    {
        //        return AuthenticateResult.Fail("No header found");
        //    }
        //    var headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        //    if (headervalue != null)
        //    {
        //        var bytes = Convert.FromBase64String(headervalue.Parameter);
        //        string credentials = Encoding.UTF8.GetString(bytes);
        //        string[] array = credentials.Split(":");
        //        string username = array[0];
        //        string password = array[1];
        //        var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Password == password);
        //        if (user != null)
        //        {
        //        var res = await _siginManager.PasswordSignInAsync(user.username, user.password, true, false);
        //        if (res.Succeeded) { 
        //            var claim = new[] { new Claim("Id", Guid.NewGuid().ToString()),
        //                new Claim("SessionExpired", DateTime.Now.AddMinutes(60).ToString("o")) };
        //            var identity = new ClaimsIdentity(claim, Scheme.Name);
        //            var principal = new ClaimsPrincipal(identity);
        //            var ticket = new AuthenticationTicket(principal, Scheme.Name);
        //            return AuthenticateResult.Success(ticket);
        //        }
        //        else
        //        {
        //            return AuthenticateResult.Fail("UnAutorized");
        //        }
        //    }
        //    else
        //    {
        //        return AuthenticateResult.Fail("Empty header");
        //    }
        //}
    }
}
