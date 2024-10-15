using System.Linq.Expressions;
using BusinessObjects;
using DataAccessLayer;
using Repositories.Interfaces;

namespace Repositories;

public class RoleRepository : IRoleRepository
{
    public IQueryable<Role> GetAll() => RoleDao.Instance.GetAll();

    public Role? Find(Expression<Func<Role, bool>> predicate) => RoleDao.Instance.Find(predicate);

    public IQueryable<Role> GetList(Expression<Func<Role, bool>> predicate) => RoleDao.Instance.GetList(predicate);

    public void Add(Role role) => RoleDao.Instance.Add(role);

    public void Update(Role role) => RoleDao.Instance.Update(role);

    public void Delete(Role role) => RoleDao.Instance.Delete(role);
}