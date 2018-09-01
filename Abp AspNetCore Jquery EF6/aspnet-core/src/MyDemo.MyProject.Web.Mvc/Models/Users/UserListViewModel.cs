using System.Collections.Generic;
using MyDemo.MyProject.Roles.Dto;
using MyDemo.MyProject.Users.Dto;

namespace MyDemo.MyProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
