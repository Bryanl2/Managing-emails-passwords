using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.Net;
using User.Management.Service.Models;
using User.Managment.API.Models;
using User.Managment.API.Models.Signup;
using IEmailService = User.Management.Service.Services.IEmailService;

namespace User.Managment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser,string role)
        {
            //Check user exist


            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

            if(userExist != null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, new Response { Status = "Error", Message = "User already exists" });
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,
            };


            if(await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (!result.Succeeded)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, new Response { Status = "Error", Message = "User failed to create" });
                }

                _userManager.AddToRoleAsync(user,role);


                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email });
                var message = new Message(user.Email,"Confirmation email link",confirmationLink!);
                _emailService.SendEmail(message);

                return StatusCode((int)HttpStatusCode.OK, new Response { Status = "Sucess", Message = "User created successfully" });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Response { Status = "Error", Message = "This role doesn't exist." });
            }
        }
        [HttpGet]
        public IActionResult TestEmail() 
        {
            var message = new Message( "bryanlr0721@gmail.com" , "Test", "<h1>Bryan Loaiza</h1>");
            
            _emailService.SendEmail(message);
            return StatusCode((int)HttpStatusCode.OK, new Response { Status = "Success",Message="Email sent Successfully"});
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user !=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Email confirmed successfully");
                }
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error");
        }
    }
}
