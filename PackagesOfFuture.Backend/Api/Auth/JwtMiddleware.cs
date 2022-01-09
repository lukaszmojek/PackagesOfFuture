using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Configuration;
using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Api.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IPofConfiguration _configuration;

    public JwtMiddleware(RequestDelegate next, IPofConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IRepository<User> userRepository)
    {
        var token = context.Request
            .Headers["Authorization"]
            .FirstOrDefault()?
            .Split(" ")
            .Last();

        if (token != null)
        {
            await attachUserToContext(context, userRepository, token);
        }

        await _next(context);
    }

    private async Task attachUserToContext(HttpContext context, IRepository<User> userRepository, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.JwtSecret());
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = await userRepository.GetByIdAsync(userId);
        }
        catch
        {
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
}