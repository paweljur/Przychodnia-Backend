using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using PrzychodniaBackend.Api.Controllers.Dto;
using PrzychodniaBackend.Api.Entities;
using PrzychodniaBackend.Api.Repositories.UserRepository;
using PrzychodniaBackend.Api.Services;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;

        public UserController(IAuthenticationService authenticationService, IUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return new ActionResult<IEnumerable<User>>(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _userRepository.GetBy(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [SwaggerResponse(typeof(void))]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            User? deletedUser =  await _userRepository.Delete(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            return deletedUser;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public ActionResult<User> Authenticate([FromBody] LoginCredentialsDto credentials)
        {
            User? user = _authenticationService.Authenticate(credentials.Username, credentials.Password);

            if(user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}
