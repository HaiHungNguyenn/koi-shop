namespace Services.Interfaces;

public interface IAuthService
{
    bool Login(string username, string password);
    bool Logout();
    bool Register(string username, string password, string role);
}