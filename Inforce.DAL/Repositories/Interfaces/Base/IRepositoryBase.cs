using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace Inforce.DAL.Repositories.Interfaces.Base;

public interface IRepositoryBase<T>
    where T : class
{
    
    IQueryable<T> FindAll(
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default);
    
    Task<T> CreateAsync(T entity);
    
    T Create(T entity);
    
    EntityEntry<T> Update(T entity);
    
    void Delete(T entity);
    
    void DeleteRange(IEnumerable<T> items);
    
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default);
    
    Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate = default,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default);
}