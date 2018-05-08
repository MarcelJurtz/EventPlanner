using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Planner.Models.Repository;
using Planner.Models.Repository.Mock;

namespace Planner
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Transient defines that a new instance is returned for each request
            services.AddTransient<IEventRepository, MockEventRepository>();
            services.AddTransient<IEventRoleRepository, MockEventRoleRepository>();
            services.AddTransient<ITeamRepository, MockTeamRepository>();
            services.AddTransient<ITeamRoleRepository, MockTeamRoleRepository>();
            services.AddTransient<IUserRepository, MockUserRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
