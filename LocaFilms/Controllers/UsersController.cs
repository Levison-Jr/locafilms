using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public string GetAllUsers()
        {
            return "Hello, World!";
        }
    }
}
