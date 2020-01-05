using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Authentication;
using PrzychodniaBackend.Api.Controllers.UserControllerDtos;
using PrzychodniaBackend.Application.UserService;
using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<UserInfo>), StatusCodes.Status200OK)]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]
        public IActionResult RegisterNewUser(NewUserDto user)
        {
            if (user.Username is null ||
                user.Password is null ||
                user.Name is null ||
                user.Surname is null ||
                user.Role is null)
            {
                return BadRequest(new ApiError("Missing required fields"));
            }

            return Ok(_userService.RegisterNewUser(new NewUser(user.Username,
                user.Password,
                user.Role,
                user.Name,
                user.Surname)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoggedInUserDto), StatusCodes.Status200OK)]
        public IActionResult Login(LoginCredentialsDto credentials)
        {
            if (credentials.Username is null || credentials.Password is null)
            {
                return BadRequest(new ApiError("Missing required fields"));
            }

            LoggedInUser? user = _userService.Login(new LoginCredentials(credentials.Username, credentials.Password));

            if (user is null)
            {
                return BadRequest(new ApiError("Invalid username or password"));
            }

            string token = _jwtService.GenerateToken(user.Id.ToString(), user.Role);
            return Ok(new LoggedInUserDto(user.Id.ToString(), user.Name, user.Surname, user.Role, token));
        }
    }
}