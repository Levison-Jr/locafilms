using AutoMapper;
using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Models;
using LocaFilms.Services;
using LocaFilms.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IIdentityService identityService,
            IUserService userService,
            IMapper mapper)
        {
            _identityService = identityService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<UserModel>, IEnumerable<UserDto>>(users);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            UserModel? user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserModel, UserDto>(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserDto createUserDto)
        {
            var result = await _identityService.Register(createUserDto);

            if (!result.Success)
                return BadRequest(new ProblemDetails {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                });

            return CreatedAtAction(
                actionName: nameof(GetUserById),
                routeValues: new { id = result.User?.Id },
                value: _mapper.Map<UserModel?, UserDto>(result.User));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<UpdateUserDto, UserModel>(updateUserDto);
            var result = await _userService.UpdateUserAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
