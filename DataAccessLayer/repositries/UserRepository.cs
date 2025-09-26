using DataAccessLayer.Context;
using DataAccessLayer.interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.repositries
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        #region Create user
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        #endregion

        #region Delete user by id
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get all users with pagination
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        #region Get user by id
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
        #endregion

        #region Update user
        public async Task<UserModel> UpdateUserAsync(int userId, UserModel user)
        {
            var findingUser = await _context.Users.FindAsync(userId);
            if (findingUser == null)
            {
                throw new Exception("user not found on following Id");
            }
            findingUser.Name = user.Name;
            findingUser.Email = user.Email;
            findingUser.Password = user.Password;

            _context.Users.Update(findingUser);
            await _context.SaveChangesAsync();
            return findingUser;
        }
        #endregion
    }
}
