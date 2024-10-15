namespace Services.Interfaces;
using BusinessObjects.Dto;
using BusinessObjects.Request.Auth;

public interface IAuthService
{
    ServiceActionResult Login(string username, string password);
    ServiceActionResult Logout();
    ServiceActionResult Register(RegisterRequest request);
}