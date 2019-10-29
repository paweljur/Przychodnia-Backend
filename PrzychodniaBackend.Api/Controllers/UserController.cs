using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.Api.Controllers.Dto;
using PrzychodniaBackend.Api.Entities;
using PrzychodniaBackend.Api.Repositories.UserRepository;
using PrzychodniaBackend.Api.Services;

namespace PrzychodniaBackend.Api.Controllers
{

    public class MyError
    {
        public string Message { get; set; }
     
        public MyError(string message)
        {
            Message = message;
        }
    }

    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public UserController(IJwtService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(long id)
        {
            User user = await _userRepository.GetBy(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userRepository.Replace(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_userRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostUser(User user)
        {
            await _userRepository.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            User? deletedUser =  await _userRepository.Delete(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return Ok(deletedUser);
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        [ProducesResponseType(typeof(CurrentUserDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyError),StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] LoginCredentialsDto credentials)
        {
            User? user = _userRepository.GetBy(credentials.Username, credentials.Password);

            if(user is null)
            {
                return BadRequest(new MyError("Username or password is incorrect"));
            }

            string token = _jwtService.GenerateToken(user.Id);
            return Ok(new CurrentUserDto(user.Role, token, user.Name, user.Surname));
        }
    }
}
