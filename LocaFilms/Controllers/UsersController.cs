using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            UserModel? user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserModel, UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<CreateUserDto, UserModel>(createUserDto);
            var result = await _userService.CreateUserAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(
                actionName: nameof(GetUserById),
                routeValues: new { id = user.Id },
                value: _mapper.Map<UserModel?, UserDto>(result.User));
        }
    }
}
