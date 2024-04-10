using AutoMapper;
using LocaFilms.Dtos;
using LocaFilms.Models;
using LocaFilms.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;
        public RentalController(IRentalService rentalService, IMapper mapper)
        {
            _rentalService = rentalService;
            _mapper = mapper;
        }

        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetRentalByUserId(int id)
        {
            var rentals = await _rentalService.GetByUserId(id);
            var result = _mapper.Map<IEnumerable<MovieRentals>, IEnumerable<RentalDto>>(rentals);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(CreateRentalDto createRentalDto)
        {
            var movieRental = _mapper.Map<CreateRentalDto, MovieRentals>(createRentalDto);
            var result = await _rentalService.CreateRental(movieRental);

            if (!result.Success)
                return BadRequest(result.Message);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRental(UpdateRentalDto updateRentalDto)
        {
            var movieRental = _mapper.Map<UpdateRentalDto, MovieRentals>(updateRentalDto);
            var result = await _rentalService.UpdateRental(movieRental);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{userId:int}/{movieId:int}")]
        public async Task<IActionResult> DeleteRental(int userId, int movieId)
        {
            var result = await _rentalService.DeleteRental(userId, movieId);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
