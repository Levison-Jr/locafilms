﻿using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieModel>> ListAsync();
        Task<MovieModel?> GetByIdAsync(int id);
        Task AddAsync(MovieModel movie);
    }
}
