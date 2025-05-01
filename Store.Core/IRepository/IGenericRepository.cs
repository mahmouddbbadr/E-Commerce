using Store.Core.Entities;
using Store.Core.Specification;

namespace Store.Core.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetEntityWithSpecification(ISpecification<T> specification);
        Task<List<T>> GetAllWithSpecification(ISpecification<T> specification);

    }
}
