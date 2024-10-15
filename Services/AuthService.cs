using BusinessObjects;
using BusinessObjects.Dto;
using Repositories;
using Repositories.Interfaces;
using Services.Constant;
using Services.Extension;
using Services.Helper;
using Services.Interfaces;

namespace Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository = new UserRepository();
    private readonly IRoleRepository _roleRepository = new RoleRepository();

    public bool Login(string username, string password)
    {
        var user = _userRepository.Find(x => x.UserName.Equals(username)) ?? throw new Exception("Not Found User");
        if (!HashedPasswordHelper.VerifyPassword(password, user.HashedPassword))
            throw new Exception("Invalid Password");
        UserSession.CurrenUser.SetUser(user.Id,user.UserName, user.Role.Name);
        return true;
    }

    public bool Logout()
    {
        UserSession.CurrenUser.ClearSession();
        return true;
    }

    public bool Register(string username, string password, string role)
    {
        var existingUser = _userRepository.Find(x => x.UserName == username);
        if (existingUser is not null)
            throw new Exception("User name already exist.");
        var existRole = EnsureRoleExist(role);
        var newUser = new User()
        {
            UserName = username,
            HashedPassword = HashedPasswordHelper.HashPassword(password),
            Role = existRole
        };
        _userRepository.Add(newUser);
        return true;
    }

    private Role EnsureRoleExist(string role)
    {
        if (!IsValidRole(role))
            throw new Exception($"Not found Role {role}.");
        var existRole = _roleRepository.Find(x => x.Name == role);
        if (existRole is not null)
            return existRole;
        var newRole = new Role()
        {
            Name = role.ToCapitalize()
        };
        _roleRepository.Add(newRole);
        return newRole;
    }

    private bool IsValidRole(string role)
    {
         return role.Equals(UserRole.Admin, StringComparison.OrdinalIgnoreCase) 
                || role.Equals(UserRole.Client, StringComparison.OrdinalIgnoreCase) 
                || role.Equals(UserRole.ShopManager, StringComparison.OrdinalIgnoreCase) 
                || role.Equals(UserRole.ShopStaff, StringComparison.OrdinalIgnoreCase);
    }
}