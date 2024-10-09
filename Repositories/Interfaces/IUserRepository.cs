using System.Linq.Expressions;
using BusinessObjects;

namespace Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetAll();
    User? Find(Expression<Func<User,bool>> predicate);
    IQueryable<User> GetList(Expression<Func<User,bool>> predicate);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}