using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIsAsync(id);
        }

        public async Task<CreateUserResponse> CreateUserAsync(UserModel user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return new CreateUserResponse(user);
            }
            catch (Exception ex)
            {
                return new CreateUserResponse($"Houve um erro durante a criação do usuário: {ex.Message}");
            }
        }
    }
}
