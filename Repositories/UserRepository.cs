using System.Linq.Expressions;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interfaces;

namespace Repositories;

public class UserRepository : IUserRepository
{
    public IQueryable<User> GetAll() => UserDao.Instance.GetAll();

    public User? Find(Expression<Func<User,bool>> predicate) => UserDao.Instance.Find(predicate);
    
    public IQueryable<User> GetList(Expression<Func<User,bool>> predicate) => UserDao.Instance.GetList(predicate);
    
    public void Add(User user) => UserDao.Instance.Add(user);

    public void Update(User user) => UserDao.Instance.Update(user);
    
    public void Delete(User user) => UserDao.Instance.Delete(user);
}