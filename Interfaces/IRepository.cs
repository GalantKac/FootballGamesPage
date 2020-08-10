using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get entity use id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Return T entity</returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Get all etities
        /// </summary>
        /// <returns>Entities T list</returns>
        Task<IReadOnlyList<T>> GetAllAsync();
        /// <summary>
        /// Get entity use specification
        /// </summary>
        /// <param name="specification">Query specification</param>
        /// <returns>Return T entity</returns>
        Task<T> GetAsync(ISpecification<T> specification);
        /// <summary>
        /// Get etities with specification
        /// </summary>
        /// <param name="specification">Query specification</param>
        /// <returns>Entities T list</returns>
        Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> specification);
        /// <summary>
        /// Method add enitity to db
        /// </summary>
        /// <param name="entity">T entity</param>
        void Add(T entity);
        /// <summary>
        /// Method remove entity from db
        /// </summary>
        /// <param name="entity">T entity</param>
        void Delete(T entity);
    }
}
