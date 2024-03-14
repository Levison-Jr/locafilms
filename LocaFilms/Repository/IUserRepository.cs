﻿using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> ListAsync();
        Task AddAsync(UserModel user);
    }
}
