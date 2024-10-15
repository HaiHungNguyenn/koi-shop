using System.Linq.Expressions;
using BusinessObjects;

namespace Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> GetAll();
    Role? Find(Expression<Func<Role,bool>> predicate);
    IQueryable<Role> GetList(Expression<Func<Role,bool>> predicate);
    void Add(Role role);
    void Update(Role role);
    void Delete(Role role);
}