using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Domain.Interfaces;
using TodoApi.Core.Infrastructure.Dao;

namespace TodoApi.Core.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDao _user;

        public UserRepository()
        {
            _user = new UserDao();
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _user.GetById(id);
            return user;
        }

        public async Task<List<User>> List()
        {
            var user_list = await _user.List();
            return user_list;
        }

        public async Task<IActionResult> Create(User user)
        {
            var created_user = await _user.Create(user);
            return new OkObjectResult(created_user);
        }

        public async Task<IActionResult> Update(User user)
        {
            var existingUser = await _user.Update(user);
            return new OkObjectResult(existingUser);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleted_user = await _user.Delete(id);
            return new OkObjectResult(deleted_user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await _user.GetByEmail(email);
            return user;
        }
    }
}
