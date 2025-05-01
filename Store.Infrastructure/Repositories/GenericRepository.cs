using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.IRepository;
using Store.Core.Specification;
using Store.Infrastructure.Data;
using Store.Infrastructure.SpecificationEvaluater;

namespace Store.Infrastructure.Repositories
{
    public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
    {
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);

        }
        
        public async Task<List<T>> GetAllWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        
        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluater<T>.GetQuery(context.Set<T>().AsQueryable(), specification);
        }
        
    }
}
