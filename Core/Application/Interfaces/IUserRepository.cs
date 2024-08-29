using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<List<User>> List();
        Task<User?> Create(User user);
        Task<User?> Update(User user, int id);
        Task<bool> Delete(int id);
        Task<User?> GetByEmail(string email);
    }
}
