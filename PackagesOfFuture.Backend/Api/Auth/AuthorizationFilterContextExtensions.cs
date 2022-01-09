using Data.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Auth;

public static class AuthorizationFilterContextExtensions
{
    public static User User(this AuthorizationFilterContext context) => 
        (User)context.HttpContext.Items["User"];
}