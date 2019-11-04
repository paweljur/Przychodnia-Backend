using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Authentication;
using PrzychodniaBackend.Api.Controllers.Dto;
using PrzychodniaBackend.Application.UserService;
using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("test")]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult ConfidentialAction()
        {
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoggedInUserDto), StatusCodes.Status200OK)]
        public IActionResult Login(LoginCredentialsDto credentials)
        {
            if (credentials.Username is null || credentials.Password is null)
            {
                return BadRequest();
            }

            LoggedInUser user = _userService.Login(new LoginCredentials(credentials.Username, credentials.Password));
            string token = _jwtService.GenerateToken(user.Id.ToString());
            return Ok(new LoggedInUserDto(user.Id.ToString(), user.Name, user.Surname, token));
        }
    }
}