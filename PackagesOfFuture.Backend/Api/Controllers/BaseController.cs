using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BaseController : ControllerBase
{
    public static User User(HttpContext context) => 
        (User)context.Items["User"];
}