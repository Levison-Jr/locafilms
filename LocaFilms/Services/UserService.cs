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
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserResponse> CreateUserAsync(UserModel user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Houve um erro durante a criação do usuário: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateUserAsync(int id, UserModel user)
        {
            UserModel? userToUpdate = await GetUserByIdAsync(id);

            if (userToUpdate == null)
                return new UserResponse($"O usuário com id {id} não existe.");

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
                return new UserResponse(userToUpdate);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Não foi possível atualizar o usuário (id = {id}). Erro: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            var userToDelete = await GetUserByIdAsync(id);

            if (userToDelete == null)
                return new UserResponse($"O usuário com id {id} não existe.");

            try
            {
                await _userRepository.DeleteAsync(userToDelete);
                return new UserResponse(userToDelete);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Houve um erro ao tentar deletar o usuário (id = {id}). Erro: {ex.Message}");
            }
        }
    }
}
