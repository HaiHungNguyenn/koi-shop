using BusinessObjects;

namespace DataAccessLayer;

public class UserDao : BaseDao<User>
{
    public UserDao() : base(new KoiShopContext())
    {
    }
    private static UserDao? _instance;

    public static UserDao Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserDao();
            }
            return _instance;
        }
    }
}