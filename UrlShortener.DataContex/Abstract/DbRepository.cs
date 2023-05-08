using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain;

namespace UrlShortener.DataContex.Abstract
{
    public abstract class DbRepository<T> : IDbRepository<T> where T : class, IDbEntity
    {

        private AppDataContext _context;
        private DbSet<T> _dbSet;

        public DbRepository(AppDataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddItemAsync(T entity)
        {
            _dbSet.Add(entity);
            return entity;

        }

        public async Task<IEnumerable<T>> AddItemsAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task ChangeItemAsync(T entity)
        {
            _dbSet.Attach(entity).State = EntityState.Modified;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var candidate = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
            _dbSet.Remove(candidate);
        }
        public async Task DeleteItemsAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                var h = _dbSet.Find(item.Id);
                _dbSet.Remove(h);
            }

        }
        public async Task<T> GetItemAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = query.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync();
        }


        public async Task<int> SaveChangesAsync()
        {

            return await _context.SaveChangesAsync();

        }

        public async Task<List<T>> GetAllItemsAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return await query.ToListAsync();
        }
    }
}
