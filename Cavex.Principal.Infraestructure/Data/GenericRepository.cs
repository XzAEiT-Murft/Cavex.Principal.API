using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cavex.Principal.Infraestructure.Data
{
    /// <summary>
    /// Implementacion generica de acceso a datos para entidades que heredan de BaseEntity.
    /// </summary>
    /// <typeparam name="T">Entidad administrada por el repositorio.</typeparam>
    public class GenericRepository<T>(CavexContext cavexContext) : IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Agrega una entidad al DbContext. El guardado se confirma con SaveAllAsync.
        /// </summary>
        public void Add(T entity)
        {
            cavexContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Devuelve el conteo de registros que cumplen la specification indicada.
        /// </summary>
        public async Task<int> GetIntAsync(ISpecification<T> specification)
        {
            var query = cavexContext.Set<T>().AsQueryable();
            query = specification.ApplyCriteria(query);
            return await query.CountAsync();
        }

        /// <summary>
        /// Indica si existe un registro con el identificador recibido.
        /// </summary>
        public bool Exists(int id)
        {
            return cavexContext.Set<T>().Any(x => x.Id == id);
        }

        /// <summary>
        /// Busca una entidad directamente por llave primaria.
        /// </summary>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await cavexContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Obtiene el primer registro que cumple la specification.
        /// </summary>
        public async Task<T?> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtiene el primer resultado proyectado que cumple la specification.
        /// </summary>
        public async Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Lista todos los registros de una entidad sin filtros.
        /// </summary>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await cavexContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Lista registros aplicando filtros, ordenamiento y paginacion de una specification.
        /// </summary>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        /// <summary>
        /// Lista resultados proyectados aplicando una specification.
        /// </summary>
        public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).ToListAsync(); 
        }

        /// <summary>
        /// Marca una entidad para eliminacion. El cambio se confirma con SaveAllAsync.
        /// </summary>
        public void Remove(T entity)
        {
            cavexContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Persiste los cambios pendientes en la base de datos.
        /// </summary>
        public async Task<bool> SaveAllAsync()
        {
            return await cavexContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Marca una entidad como modificada para que EF Core genere el UPDATE correspondiente.
        /// </summary>
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



        /// <summary>
        /// Cuenta registros aplicando solo el filtro base de la specification, sin paginacion.
        /// </summary>
        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            var query = cavexContext.Set<T>().AsQueryable();

            query = specification.ApplyCriteria(query);

            return await query.CountAsync();
        }
    }
}
