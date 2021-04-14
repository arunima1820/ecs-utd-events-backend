using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UTD_ECS_Events_WebAPI.Repositories;
using UTD_ECS_Events_WebAPI.Services;
using Serilog;
using FirebaseAuth;

namespace UTD_ECS_Events_WebAPI
{
    public class Startup
    {
        private const string PROJECT_ID = "utdecsevents-9bed0";
        private const string ALLOW_ALL = "allowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS: allow all domains
            services.AddCors(options =>
                options.AddPolicy(ALLOW_ALL,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    })
            );

            // Required for Firebase Auth
            void options(FirebaseAuthenticationOptions o)
            {
                o.FirebaseProjectId = PROJECT_ID;
            }

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "Default";
            }).AddScheme<FirebaseAuthenticationOptions, FirebaseAuthenticationHandler>("Default", options);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            //    dependency injection
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<IEventsRepository, EventsRepository>();
            services.AddTransient<IOrgsRepository, OrgsRepository>();
            services.AddTransient<IOrgsService, OrgsService>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<ITagsService, TagsService>();

            //    Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Order of function calls below VERY IMPORTANT!
            // Check middleware order of events for .NET Core Web Api
            app.UseHttpsRedirection();
            app.UseCors(ALLOW_ALL);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
