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

        public async Task<SaveUserResponse> CreateUserAsync(UserModel user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return new SaveUserResponse(user);
            }
            catch (Exception ex)
            {
                return new SaveUserResponse($"Houve um erro durante a criação do usuário: {ex.Message}");
            }
        }

        public async Task<SaveUserResponse> UpdateUserAsync(int id, UserModel user)
        {
            UserModel? userToUpdate = await GetUserByIdAsync(id);

            if (userToUpdate == null)
                return new SaveUserResponse($"O usuário com id {id} não existe.");

            userToUpdate.Name = user.Name;
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.Email = user.Email;
            userToUpdate.Phone = user.Phone;
            userToUpdate.Perfil = user.Perfil;
            userToUpdate.IsActive = user.IsActive;
            userToUpdate.Balance = user.Balance;

            try
            {
                await _userRepository.UpdateAsync(userToUpdate);
                return new SaveUserResponse(userToUpdate);
            }
            catch (Exception ex)
            {
                return new SaveUserResponse($"Não foi possível atualizar o usuário (id = {id}). Erro: {ex.Message}");
            }
        }
    }
}
