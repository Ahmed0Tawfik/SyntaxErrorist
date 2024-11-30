using SyntaxErrorist.Infrastructure.Context;
using SyntaxErrorist.Services.Interfaces;

namespace SyntaxErrorist.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {   
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if(_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IGenericRepository<T>;
            }

            var repository = new GenericRepository<T>(_context);
            _repositories[typeof(T)] = repository;
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (var repository in _repositories.Values)
                    {
                        if (repository is IDisposable disposableRepository)
                        {
                            disposableRepository.Dispose();
                        }
                    }

                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
