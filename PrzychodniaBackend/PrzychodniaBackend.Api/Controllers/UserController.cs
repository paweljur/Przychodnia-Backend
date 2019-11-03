using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(void),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoggedInUser),StatusCodes.Status200OK)]
        public IActionResult Login(LoginCredentialsDto credentials)
        {
            if (credentials.Username is null || credentials.Password is null)
            {
                return BadRequest();
            }

            LoggedInUser user = _userService.Login(new LoginCredentials(credentials.Username, credentials.Password));
            return Ok(user);
        }
    }
}