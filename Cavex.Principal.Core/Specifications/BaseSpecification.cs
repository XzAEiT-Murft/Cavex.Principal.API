using Cavex.Principal.Core.Contract;
using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications
{
    /// <summary>
    /// Define los criterios comunes que una consulta puede aplicar sobre una entidad.
    /// </summary>
    /// <typeparam name="T">Entidad sobre la que se construye la consulta.</typeparam>
    public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        protected BaseSpecification() : this(null) { }

        /// <summary>
        /// Expresion de filtro que se traduce a WHERE cuando EF Core ejecuta la consulta.
        /// </summary>
        public Expression<Func<T, bool>>? Criteria => criteria;

        /// <summary>
        /// Expresion de ordenamiento ascendente.
        /// </summary>
        public Expression<Func<T, object>>? OrderBy { get; private set; }

        /// <summary>
        /// Expresion de ordenamiento descendente.
        /// </summary>
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        /// <summary>
        /// Indica si la consulta debe eliminar duplicados.
        /// </summary>
        public bool IsDistinct { get; private set; }

        /// <summary>
        /// Cantidad maxima de registros que debe tomar la consulta.
        /// </summary>
        public int Take { get; private set; }

        /// <summary>
        /// Cantidad de registros que debe omitir la consulta para paginar.
        /// </summary>
        public int Skip { get; private set; }

        /// <summary>
        /// Indica si se deben aplicar Skip y Take.
        /// </summary>
        public bool IsPagingEnabled { get; private set; }

        /// <summary>
        /// Aplica unicamente el filtro base. Se usa para conteos sin paginacion.
        /// </summary>
        public IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            if (Criteria is not null)
            {
                query = query.Where(Criteria);
            }
            return query;
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyDistinct()
        {
            IsDistinct = true;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }


    }

    /// <summary>
    /// Specification que ademas proyecta el resultado hacia un tipo distinto.
    /// </summary>
    /// <typeparam name="T">Entidad consultada.</typeparam>
    /// <typeparam name="TResult">Tipo de salida proyectado.</typeparam>
    public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria) :
        BaseSpecification<T>(criteria), ISpecification<T, TResult>
    {
        protected BaseSpecification() : this(null!) { }

        /// <summary>
        /// Expresion SELECT usada para proyectar la entidad a otro tipo.
        /// </summary>
        public Expression<Func<T, TResult>>? Select { get; private set; }

        protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
        {
            Select = selectExpression;
        }
    }

}
