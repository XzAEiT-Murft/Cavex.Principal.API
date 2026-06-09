using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cavex.Principal.Infraestructure.Data
{
    public class GenericRepository<T>(CavexContext cavexContext) : IGenericRepository<T> where T : BaseEntity
    {
        #region metodos anteriores
        public void Add(T entity)
        {
            cavexContext.Set<T>().Add(entity);
        }

        public async Task<int> GetIntAsync(ISpecification<T> specification)
        {
            var query = cavexContext.Set<T>().AsQueryable();
            query = specification.ApplyCriteria(query);
            return await query.CountAsync();
        }

        public bool Exists(int id)
        {
            return cavexContext.Set<T>().Any(x => x.Id == id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await cavexContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await cavexContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).ToListAsync(); 
        }

        public void Remove(T entity)
        {
            cavexContext.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await cavexContext.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            cavexContext.Set<T>().Attach(entity);
            cavexContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification <T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(cavexContext.Set<T>().AsQueryable(), specification);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return SpecificationEvaluator<T>.GetQuery<T, TResult>(cavexContext.Set<T>().AsQueryable(), specification);
        }



        public Task<int> CountAsync(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
