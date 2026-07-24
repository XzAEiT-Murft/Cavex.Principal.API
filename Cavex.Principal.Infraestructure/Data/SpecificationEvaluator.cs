using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Infraestructure.Data
{
    /// <summary>
    /// Convierte una specification en una consulta IQueryable que EF Core puede traducir a SQL.
    /// </summary>
    /// <typeparam name="T">Entidad base consultada.</typeparam>
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        /// <summary>
        /// Aplica filtro, ordenamiento, distinct y paginacion sobre una consulta de entidades.
        /// </summary>
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specification)
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            if (specification.Includes != null)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specification.IncludeStrings != null)
            {
                query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            if (specification.IsDistinct)
            {
                query = query.Distinct();
            }
            if (specification.IsPagingEnabled)
            {
                // La paginacion se aplica al final para mantener estable el orden de la consulta.
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }

        /// <summary>
        /// Aplica una specification con proyeccion para consultas que devuelven un tipo distinto a la entidad.
        /// </summary>
        public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query, ISpecification<T, TResult> specification)
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            if (specification.Includes != null)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specification.IncludeStrings != null)
            {
                query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            var selectQuery = query as IQueryable<TResult>;
            if (specification.Select != null)
            {
                selectQuery = query.Select(specification.Select);
            }

            if (specification.IsDistinct)
            {
                selectQuery = selectQuery?.Distinct();
            }

            if (specification.IsPagingEnabled)
            {
                // La paginacion se aplica despues de la proyeccion para conservar el mismo contrato.
                selectQuery = selectQuery?.Skip(specification.Skip).Take(specification.Take);
            }

            return selectQuery ?? query.Cast<TResult>();
        }
    }
}
