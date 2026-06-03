using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }

        Expression<Func<T, object>>? OrderByDescending { get; }

        bool IsDistinct { get; }
        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }

        IQueryable<T> ApplyCriteria(IQueryable<T> query);

    }

    /// <summary>
    /// el uso de esta interfaz nos permite realizar un regreso de un tipo diferente al resultado esperado.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Select { get; }
    }
}

