using BusinessObjects;
using BusinessObjects.Dto;
using BusinessObjects.Request.Auth;
using Microsoft.EntityFrameworkCore;
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

    public ServiceActionResult Login(string username, string password)
    {
        var user = _userRepository.GetAll().Include(x => x.Role).FirstOrDefault(x => x.UserName == username);
        if(user is null)
            return new ServiceActionResult()
            {
                IsSuccess = false,
                Message = "Invalid username or password"
            };
        if (!HashedPasswordHelper.VerifyPassword(password, user.HashedPassword))
            return new ServiceActionResult() {
                IsSuccess = false,
                Message = "Invalid username or password"
            };
        UserSession.CurrenUser.SetUser(user.Id,user.UserName, user.Role.Name);
        return new ServiceActionResult();
    }

    public ServiceActionResult Logout()
    {
        UserSession.CurrenUser.ClearSession();
        return new ServiceActionResult();
    }

    public ServiceActionResult Register(RegisterRequest request)
    {
        var existingUser = _userRepository.Find(x => x.UserName == request.UserName);
        if (existingUser is not null)
            return new ServiceActionResult() { 
                IsSuccess = false,
                Message = "Username is already exist."
            };
        var existRole = EnsureRoleExist(request.Role);
        if (existRole is null)
            return new ServiceActionResult()
            {
                IsSuccess = false,
                Message = $"{request.Role} does not exist."
            };
        var newUser = new User()
        {
            UserName = request.UserName,
            HashedPassword = HashedPasswordHelper.HashPassword(request.Password),
            Email = request.Email,
            RoleId = existRole.Id
        };
        _userRepository.Add(newUser);
        return new ServiceActionResult();
    }

    private Role? EnsureRoleExist(string role)
    {
        if (!IsValidRole(role))
            return null;
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