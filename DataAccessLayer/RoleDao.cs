using BusinessObjects;

namespace DataAccessLayer;

public class RoleDao : BaseDao<Role>
{
    public RoleDao() : base(new KoiShopContext())
    {
    }

    private static RoleDao? _instance;
    public static RoleDao Instance {
        get
        {
            if (_instance == null)
            {
                _instance = new RoleDao();
            }
            return _instance;
        }
    }
}