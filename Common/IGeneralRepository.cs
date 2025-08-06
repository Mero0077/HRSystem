using System.Linq.Expressions;

namespace HRSystem.Common
{
    public interface IGeneralRepository<T>
    {
            public IQueryable<T> GetAll();

            public IQueryable<T> Get(Expression<Func<T, bool>> expression);

            public Task<T> GetOneWithTrackingAsync(Expression<Func<T, bool>> expression);

            public Task<T> GetOneByIdAsync(Guid Id);

            public Task<T> AddAsync(T entity);

            public Task<T> UpdateAsync(T entity);

            public Task UpdateIncludeAsync(T entity, params string[] modifiedProperties);

            public Task<T> DeleteAsync(Guid Id);

            public Task<bool> IsExists(Guid Id);

            public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

            public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        }
    }