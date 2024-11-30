using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace SyntaxErrorist.Services.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            CancellationToken cancellationToken = default);
        

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        // Pagination and Sorting
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageNumber,
            int pageSize,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            CancellationToken cancellationToken = default);
    }
}
