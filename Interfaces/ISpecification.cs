using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Football.Interfaces
{
    public interface ISpecification<T>
    {
        /// <summary>
        /// Query criteria
        /// </summary>
        Expression<Func<T,bool>> Criteria { get; } // query specification
        /// <summary>
        /// List includes objects
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; } //list added objects
        Expression<Func<T, object>> OrderByAsc { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
    }
}
