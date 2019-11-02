using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.UserController.Dto;
using PrzychodniaBackend.Api.Services;
using PrzychodniaBackend.Core.Application.UserService;
using PrzychodniaBackend.Core.Application.UserService.Dto;

namespace PrzychodniaBackend.Api.Controllers.UserController
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public UserController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult RegisterUser(NewUserDto newUser)
        {
            if (newUser.Role is null || newUser.Username is null || newUser.Password is null)
            {
                return BadRequest(new ApiError("Role, username and password are required for new user"));
            }

            _userService.RegisterUser(new NewUser(newUser.Role, newUser.Username, newUser.Password, newUser.Name, newUser.Surname));

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        public IActionResult GetAllForAdministration()
        {
            IEnumerable<SafeUser> users = _userService.GetAllForAdministration();
            return Ok(users.Select(user => new UserDto(user.Id, user.Role, user.Username, user.Name, user.Surname)));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthenticatedUserDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError),StatusCodes.Status400BadRequest)]
        public IActionResult Login(LoginCredentialsDto credentials)
        {
            if (credentials.Username is null || credentials.Password is null)
            {
                return BadRequest(new ApiError("Required username and password"));
            }

            SafeUser? user = _userService.Login(new LoginCredentials(credentials.Username, credentials.Password));

            if(user is null)
            {
                return BadRequest(new ApiError("Username or password is incorrect"));
            }

            string token = _jwtService.GenerateToken(user.Id);
            return Ok(new AuthenticatedUserDto(user.Role, token, user.Name, user.Surname));
        }
    }
}
