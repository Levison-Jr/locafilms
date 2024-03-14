using LocaFilms.Dtos;
using LocaFilms.Models;
using LocaFilms.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            var result = await _userService.CreateUserAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(
                actionName: nameof(CreateUser),
                routeValues: new { id = user.Id },
                value: result.User);
        }
    }
}
