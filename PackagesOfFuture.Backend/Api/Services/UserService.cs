﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Configuration;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

    public class UserService : IUserService
    {
        private readonly IPofConfiguration _configuration;

        public UserService(IPofConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Authenticate(User user) => GenerateJwtToken(user);

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.JwtSecret();
            var key = Encoding.ASCII.GetBytes(secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()), 
                    new Claim("role", user.Type.ToString())
                }),
                
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
