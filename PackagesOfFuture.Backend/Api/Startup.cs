using System;
using System.IO;
using System.Reflection;
using Api.Services;
using AutoMapper;
using Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
{
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSingleton<IUserService, UserService>();

#if DEBUG
            services.AddDbContext<DbContext, PackagesOfFutureDbContext>(builder =>
                    builder.UseNpgsql(Configuration.GetConnectionString("DatabaseUrl"))
                        .EnableSensitiveDataLogging())
                .RegisterRepositories();      
#endif
            
#if RELEASE
            //TODO: Add secure configuration here once we would want to start deploying somewhere
            services.AddDbContext<DbContext, PackagesOfFutureDbContext>(builder =>
                    builder.UseNpgsql(Configuration.GetConnectionString("DatabaseUrl"))
                        .EnableSensitiveDataLogging())
                .RegisterRepositories();    
#endif
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}