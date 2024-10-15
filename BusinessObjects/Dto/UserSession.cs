namespace BusinessObjects.Dto;

public class UserSession
{
    private static UserSession? _current;
    public static UserSession CurrenUser => _current ??= new UserSession();
    
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }

    public void SetUser(Guid id, string name, string role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public void ClearSession()
    {
        Id = Guid.Empty;
        Name = null;
        Role = null;
    }
    
    public bool IsLoggedIn => Guid.Empty.Equals(this.Id);
}