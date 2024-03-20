﻿using LocaFilms.Contexts;
using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        public async Task<IEnumerable<MovieModel>> ListAsync()
        {
            return await _appDbContext.Movies.ToListAsync();
        }

        public async Task<MovieModel?> GetMovieById(int id)
        {
            return await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}