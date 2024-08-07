using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Application.Interfaces;

namespace TodoApi.Core.Domain.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

        public async Task<User?> GetById(int id)
        {
            if (id < 0)
                throw new ArgumentException("User cannot be null.");

            var user = await _repository.GetById(id);
            return user;
        }

        public async Task<List<User>> List()
        {
            return await _repository.List();
        }

        public async Task<User?> Create(User user)
        {
            if (user == null)
                throw new ArgumentException("User cannot be null.");

            return await _repository.Create(user);
        }

        public async Task<User?> Update(User user, int id)
        {
            if (user == null)
                throw new ArgumentException("User cannot be null.");

            var existingUser = await _repository.GetById(id);
            if (existingUser is null)
                return null;

            return await _repository.Update(user, id);
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id value.");

            var existingUser = await _repository.GetById(id);
            if (existingUser is null)
                return false;

            return await _repository.Delete(id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.");

            return await _repository.GetByEmail(email);
        }
    }
}
