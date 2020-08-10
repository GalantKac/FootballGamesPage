using Football.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Variables
        private readonly DB_Football_GamesContext db = null;
        private DbSet<T> dbSet;
        #endregion Variables

        #region Methods
        public Repository(DB_Football_GamesContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }

        private IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specification)
        {
            //Add query specifications
            if (specification.Criteria != null)
                query.Where(specification.Criteria);

            if (specification.OrderByAsc != null)
                query.OrderBy(specification.OrderByAsc);

            if (specification.OrderByDesc != null)
                query.OrderByDescending(specification.OrderByDesc);

            //Add all objects from list to query
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
        #endregion Methods

        #region IRepository methods
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(ISpecification<T> specification)
        {
            return await GetQuery(dbSet.AsQueryable(), specification).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> specification)
        {
            return await GetQuery(dbSet.AsQueryable(), specification).ToListAsync();
        }
        #endregion IRepository methods
    }
}
