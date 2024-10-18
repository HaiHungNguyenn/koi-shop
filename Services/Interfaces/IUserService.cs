using BusinessObjects.Dto;
using BusinessObjects.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        ServiceActionResult GetUsersByRole(Guid roleId);
        ServiceActionResult GetStaffs();
        ServiceActionResult CreateStaff(CreateUserRequest request);
    }
}
