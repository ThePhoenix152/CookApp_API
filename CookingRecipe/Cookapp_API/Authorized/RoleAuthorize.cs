
using Cookapp_API.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Cookapp_API.Authorized
{
    public class RoleAuthorize : AuthorizeAttribute
    {
        //public RoleAuthorize(params AccountRole[] allowedRoles)
        //{
        //    var allowedRolesAsStrings = allowedRoles.Select(Enum.AccountRole());
        //    Roles = string.Join(",", allowedRolesAsStrings);
        //}
    }
}
