using System;
using System.Net;
using KeraNaidi.Data.Entities;
using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Quetzalcoatl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, 
            IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
        }


        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(AuthenticatedResponse))]
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                if(await _userService.RegisterUser(registerModel))
                {
                    return Ok("User created successfully");
                }
                return Ok(new AuthenticatedResponse{ Status = "Success", Message = "User created successfully"});
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthenticatedResponse(){ Message = ex.Message, Status = "Error"});
            }
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(AuthenticatedResponse))]
        [AllowAnonymous]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel registerModel)
        {
            try
            {
                if(await _userService.RegisterAdmin(registerModel))
                {
                    return Ok(new AuthenticatedResponse { Status = "Success", Message = "User created successfully" });
                }
                else
                {
                    return BadRequest(new AuthenticatedResponse { Status = "Failure", Message = "User Was not created" });
                }
                
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthenticatedResponse(){ Message = ex.Message, Status = "Error"});
            }
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(TokenResponse))]        
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var response = await _userService.Login(loginModel);
            if(!string.IsNullOrEmpty(response.Token))
            {
                return Ok(response);
            }
            return Unauthorized();
        }
    }
}
