using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NETCoreWebExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //ATTENTION -  Reverse order will fail. Default files sets project to look for default files
            //Use static files tells web app to serve static files. Calling in reverse results in no 
            //default files found by UseStaticFiles
            app.UseDefaultFiles();
            //Need to add a package. Check project.json for
            //"Microsoft.AspNetCore.StaticFiles": "1.0.0"
            app.UseStaticFiles();
        }
    }
}
