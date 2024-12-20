﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SyntaxErrorist.Infrastructure.Context;
using SyntaxErrorist.Services.Interfaces;
using System.Linq.Expressions;

namespace SyntaxErrorist.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.CountAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            query = query.Where(predicate);

            int totalCount = await query.CountAsync(cancellationToken);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return (items, totalCount);
        }

        public Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
