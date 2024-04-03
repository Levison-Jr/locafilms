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

        [HttpPost]
        public async Task<IActionResult> CreateRental(CreateRentalDto createRentalDto)
        {
            var movieRental = _mapper.Map<CreateRentalDto, MovieRentals>(createRentalDto);
            var result = await _rentalService.CreateRental(movieRental);

            if (!result.Success)
                return BadRequest($"Não foi possível criar o aluguel. Erro: {result.Message}");

            return Created();
        }
    }
}
