using DataAccessLayer.interfaces;
using DataAccessLayer.Models;

namespace WebAPIApplication.Services
{
    public interface IUserService
    {
        public Task<UserModel> CreateUserAsync(UserModel user);
        public Task<bool> DeleteUserAsync(int id);
        public Task<IEnumerable<UserModel>> GetAllUsersAsync(int pageNumber, int pageSize);
        public Task<UserModel> GetUserByIdAsync(int id);
        public Task<UserModel> UpdateUserAsync(int userId, UserModel user);

    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repository)
        {
            _repo = repository;
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            try
            {
                return await _repo.CreateUserAsync(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                return await _repo.DeleteUserAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _repo.GetAllUsersAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<UserModel> GetUserByIdAsync(int id)
        {
            try
            {
                return _repo.GetUserByIdAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> UpdateUserAsync(int userId, UserModel user)
        {
            try
            {

                return await _repo.UpdateUserAsync(userId, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
