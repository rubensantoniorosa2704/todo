using Microsoft.AspNetCore.Mvc;

namespace TodoApi.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(int id);
        Task<List<TEntity>> List();
        Task<IActionResult> Create(TEntity entity);
        Task<IActionResult> Update(TEntity entity);
        Task<IActionResult> Delete(int id);
    }
}
