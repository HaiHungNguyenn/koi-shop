using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class BaseDao<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly KoiShopContext _dbContext;

    public BaseDao(KoiShopContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IQueryable<T> GetAll() => _dbSet;
    public IQueryable<T> GetList (Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
    public T? Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).FirstOrDefault();
    public bool Add(T entity)
    {
        try
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
        
    }
    public bool Update(T entity)
    {
        try
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Delete(T entity)
    {
        try
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    
}