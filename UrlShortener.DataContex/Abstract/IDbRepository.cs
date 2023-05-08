using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain;

namespace UrlShortener.DataContex.Abstract
{
    public interface IDbRepository<T>
       where T : class, IDbEntity
    {

        Task<List<T>> GetAllItemsAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);

        Task<T> AddItemAsync(T item);

        Task<IEnumerable<T>> AddItemsAsync(IEnumerable<T> items);

        Task<T> GetItemAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);

        Task ChangeItemAsync(T item);

        Task DeleteItemAsync(Guid id);
        Task DeleteItemsAsync(IEnumerable<T> entities);

        Task<int> SaveChangesAsync();
    }
}
