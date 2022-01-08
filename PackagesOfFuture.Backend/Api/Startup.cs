using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Configuration;
using Api.Services;
using Data;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ResourceEnums;

namespace Api;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }
        );

        services.AddMediatR(typeof(Startup));
        services.AddAutoMapper(typeof(Startup).Assembly);
        
        services.AddSingleton<IPofConfiguration, PofConfiguration>();
        services.AddSingleton<IUserService, UserService>();
        // services.AddSingleton<IAuthorizationHandler, UserTypeHandler>();
        
#if DEBUG
        services.AddDbContext<DbContext, PackagesOfFutureDbContext>(
                builder => builder.UseNpgsql(Configuration.GetConnectionString("DatabaseUrl"))
                    .EnableSensitiveDataLogging()
            )
            .RegisterRepositories();
#endif
        // services.AddAuthorization(
        //     options =>
        //     {
        //         options.AddPolicy(
        //             "Admin",
        //             policy => policy.Requirements.Add(new UserTypeRequirement(UserType.Administrator))
        //         );
        //     }
        // );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}

public class UserTypeRequirement : IAuthorizationRequirement
{
    public UserType UserType { get; }
    public UserTypeRequirement(UserType userType) => UserType = userType;
}

// [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
// public class AuthorizeAttribute : Attribute, IAuthorizationFilter
// {
//     public void OnAuthorization(AuthorizationFilterContext context)
//     {
//         var user = (User)context.HttpContext.Items["User"];
//         if (user == null)
//         {
//             // not logged in
//             context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
//         }
//     }
// }
//
// public class UserTypeHandler : AuthorizationHandler<UserTypeRequirement>
// {
//     protected override Task HandleRequirementAsync(
//         AuthorizationHandlerContext context, UserTypeRequirement requirement)
//     {
//         // var userTypeClaim = context.User.FindFirst(
//         //     c => == ClaimTypes.user && c.Issuer == "http://contoso.com");
//         //
//         // if (dateOfBirthClaim is null)
//         // {
//         //     return Task.CompletedTask;
//         // }
//         //
//         // if (calculatedAge >= requirement.UserType)
//         // {
//         //     context.Succeed(requirement);
//         // }
//
//         return Task.CompletedTask;
//     }
// }