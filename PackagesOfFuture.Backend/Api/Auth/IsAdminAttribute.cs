using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResourceEnums;
#pragma warning disable CS1591

namespace Api.Auth;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class IsAdminAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.User();
        
        if (user?.Type != UserType.Administrator)
        {
            context.Result = new JsonResult(new { message = "Forbidden" })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}