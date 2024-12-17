using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class GenericRepository<T>(AppDBContext appContext) : IGenericRepository<T> where T : class
{
    protected AppDBContext _context = appContext;
    private  DbSet<T> _dbSet => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable().AsNoTracking();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).AsNoTracking();
    }

    public async ValueTask<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}