using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Application.Interfaces
{
    public interface IUserDao
    {
        Task<User?> GetById(int id);
        Task<List<User>> List();
        Task<User?> Create(string name, string email, string password);
        Task<User?> Update(int id, string name, string email, string password);
        Task<bool> Delete(int id);
        Task<User?> GetByEmail(string email);
    }
}
