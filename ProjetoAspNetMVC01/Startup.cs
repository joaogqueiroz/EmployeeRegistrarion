using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoAspNetMVC01.Domain.Service;
using ProjetoAspNetMVC01.Interfaces;
using ProjetoAspNetMVC01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01
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
            //configuring to use MVC on project
            services.AddControllersWithViews();
            //services.AddMvc(); VS2017

            //Taking the connetionstring for datebase
            //It is in appsettings.json file.
            var connectionstring = Configuration.GetConnectionString("ProjetoAspNetMVC01");

            //Initializing EmployeeRepository
            services.AddTransient<IEmployeeRepository, EmployeeRepository>
                (map => new EmployeeRepository(connectionstring));

            //Initializing EmployeeDomainService
            services.AddTransient<EmployeeDomainService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Employee}/{action=Registration}");
            });
        }
    }
}
