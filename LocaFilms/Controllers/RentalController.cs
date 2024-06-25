using AutoMapper;
using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
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
        
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetRentalByUserId(string id)
        {
            var rentals = await _rentalService.GetByUserId(id);
            var result = _mapper.Map<IEnumerable<MovieRentals>, IEnumerable<RentalDto>>(rentals);
            
            return Ok(result);
        }

        [HttpGet("{userId}/{movieId:int}")]
        public async Task<IActionResult> GetRentalByUserMovieIds(string userId, int movieId)
        {
            var rental = await _rentalService.GetByUserMovieIds(userId, movieId);

            if (rental == null)
                return NotFound();

            return Ok(_mapper.Map<MovieRentals?, RentalDto>(rental));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(CreateRentalDto createRentalDto)
        {
            var movieRental = _mapper.Map<CreateRentalDto, MovieRentals>(createRentalDto);
            var result = await _rentalService.CreateRental(movieRental);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(
                actionName: nameof(GetRentalByUserMovieIds),
                routeValues: new { userId = movieRental.UserId, movieId = movieRental.MovieId },
                value: _mapper.Map<MovieRentals?, RentalDto>(result.MovieRental));
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
        public async Task<IActionResult> DeleteRental(string userId, int movieId)
        {
            var result = await _rentalService.DeleteRental(userId, movieId);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
