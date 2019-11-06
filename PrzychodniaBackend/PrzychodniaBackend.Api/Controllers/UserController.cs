using System.Collections.Generic;
using System.Linq;
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

        [HttpGet()]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserInfo> users = _userService.GetAllUsers();

            return Ok(users.Select(user =>
                new UserInfoDto(user.Id, user.Username, user.Role, user.Name, user.Surname)));
        }

        [HttpPost()]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult RegisterNewUser(NewUserDto user)
        {
            if (user.Username is null || user.Password is null || user.Role is null)
            {
                return BadRequest();
            }

            _userService.RegisterNewUser(new NewUser(user.Username, user.Password, user.Role, user.Name, user.Surname));
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoggedInUserDto), StatusCodes.Status200OK)]
        public IActionResult Login(LoginCredentialsDto credentials)
        {
            if (credentials.Username is null || credentials.Password is null)
            {
                return BadRequest("No username or password provided");
            }

            LoggedInUser? user = _userService.Login(new LoginCredentials(credentials.Username, credentials.Password));

            if (user is null)
            {
                return BadRequest("Invalid username or password");
            }

            string token = _jwtService.GenerateToken(user.Id.ToString());
            return Ok(new LoggedInUserDto(user.Id.ToString(), user.Name, user.Surname, token));
        }
    }
}