﻿using AutoMapper;
using LocaFilms.Dtos;
using LocaFilms.Models;
using LocaFilms.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            var result = _mapper.Map<IEnumerable<MovieModel>, IEnumerable<MovieDto>>(movies);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<CreateMovieDto, MovieModel>(createMovieDto);
            var result = await _movieService.CreateMovieAsync(movie);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(
                actionName: nameof(GetMovieById),
                routeValues: new { id = movie.Id },
                value: _mapper.Map<MovieModel?, MovieDto>(result.Movie));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = _mapper.Map<UpdateMovieDto, MovieModel>(updateMovieDto);
            var result = await _movieService.UpdateMovieAsync(id, movie);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
