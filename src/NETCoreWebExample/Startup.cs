using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NETCoreWebExample.Services;
using NETCoreWebExample.Models;

namespace NETCoreWebExample
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            //Stores the json config file
            //Note .SetBasePath must be called or error is thrown
            //Environment variables will overwrite Json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Singleton because the config file should only exist once
            services.AddSingleton(_config);


            if (_env.IsDevelopment())
            {
                //This is needed for running services on controllers
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //Real service here
            }
            //Will register Entity Framework and the Context
            services.AddDbContext<WorldContext>();
            //Create 1 per request cycle. TODO Need to review what scoped is
            services.AddScoped<IWorldRepository, WorldRepository>();
            services.AddTransient<WorldContextSeedData>();
            services.AddLogging();
            //ATTENTION - MVC requires classes, interfaces, etc.
            //This will register it
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            WorldContextSeedData seeder,
            ILoggerFactory factory)
        {
            //Used to see errors, would only apply to development machines
            //You can set what the machine is in the project properties/debug
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                factory.AddDebug(LogLevel.Information);
            }
            else
            {
                factory.AddDebug(LogLevel.Error);
            }
            //ATTENTION -  Reverse order will fail. Default files sets project to look for default files
            //Use static files tells web app to serve static files. Calling in reverse results in no 
            //default files found by UseStaticFiles
            //app.UseDefaultFiles();
            //Need to add a package. Check project.json for
            //"Microsoft.AspNetCore.StaticFiles": "1.0.0"
            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                //Can be written like a regular method, this makes it more readable
                config.MapRoute(
                    name: "Default",
                    //Note ID is optional
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}
