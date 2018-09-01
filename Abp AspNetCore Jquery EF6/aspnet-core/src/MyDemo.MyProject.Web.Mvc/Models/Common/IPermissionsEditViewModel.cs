using System.Collections.Generic;
using MyDemo.MyProject.Roles.Dto;

namespace MyDemo.MyProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}