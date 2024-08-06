#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente

using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetById(int id);
        Task<List<User>> List();
        Task<IActionResult> Create(User user);
        Task<IActionResult> Update(User user);
        Task<IActionResult> Delete(int id);
        Task<User?> GetByEmail(string email);
    }
}
