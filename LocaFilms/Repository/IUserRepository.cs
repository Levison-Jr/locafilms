﻿using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> ListAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task AddAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(UserModel user);
    }
}
