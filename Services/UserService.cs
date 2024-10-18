using BusinessObjects;
using BusinessObjects.Dto;
using BusinessObjects.Request.User;
using Microsoft.Identity.Client;
using Repositories;
using Repositories.Interfaces;
using Services.Constant;
using Services.Helper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public ServiceActionResult CreateStaff(CreateUserRequest request)
        {
            EnsureHasStaffRole();
            var staffRole = _roleRepository.GetAll().FirstOrDefault(x => x.Name == UserRole.ShopStaff);
            var staff = new User()
            {
                Address = request.Address,
                Email = request.Email,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                RegistrationDate = request.RegistrationDate,
                HashedPassword = HashedPasswordHelper.HashPassword(request.Password),
                UserName = request.UserName,
                RoleId = staffRole!.Id
            };
            _userRepository.Add(staff);
            return new ServiceActionResult() { 
                IsSuccess = true,
            };
        }

        public ServiceActionResult GetStaffs()
        {
            var staffRole = _roleRepository.GetAll().FirstOrDefault(x => x.Name == UserRole.ShopStaff);
            return GetUsersByRole((staffRole is not null) ? staffRole.Id : Guid.Empty);
        }

        public ServiceActionResult GetUsersByRole(Guid roleId)
        {
            var users = _userRepository.GetAll().Where(x => x.RoleId == roleId);
            if (!users.Any())
                return new ServiceActionResult()
                {
                    Data = new List<UserDto>()
                };
            var userdtos = users.Select(x => new UserDto()
            {
                Address = x.Address,
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                RegistrationDate = x.RegistrationDate,
                UserName = x.UserName
            });
            return new ServiceActionResult()
            {
                Data = userdtos.ToList()
            };
        }
        private void EnsureHasStaffRole() {
            if (!_roleRepository.GetAll().Any(x => x.Name == UserRole.ShopStaff)) {
                var role = new Role()
                {
                    Name = UserRole.ShopStaff,
                };
                _roleRepository.Add(role);
            }
        }
    }
}
