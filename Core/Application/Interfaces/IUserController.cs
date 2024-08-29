using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Application.Interfaces
{
    public interface IUserController
    {
        Task<IResult> GetById(int id);
        Task<IResult> List();
        Task<IResult> Create(User user);
        Task<IResult> Update(User user);
        Task<IResult> Delete(int id);
        Task<IResult> GetByEmail(string email);
    }
}
