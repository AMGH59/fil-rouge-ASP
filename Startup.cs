using devTalksASP.Interfaces;
using devTalksASP.Models;
using devTalksASP.Repositories;
using devTalksASP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP
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
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped<SigninService>();
            services.AddScoped<IRepository<Message>, MessageRepository>();
            services.AddScoped<IRepository<Topic>, TopicRepository>();
            services.AddScoped<IRepository<Techno>, TechnoRepository>();
            services.AddTransient<StateManagementService>();
            services.AddScoped<TopicService>();
            services.AddTransient<FormatService>();
            services.AddScoped<NavService>();
            services.AddTransient<TechnoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "signin",
                    pattern: "/Signin",
                    defaults: "index"
                    );
                endpoints.MapControllerRoute(
                    name: "profile",
                    pattern: "/Profile",
                    defaults: "index"
                    );
            });
        }
    }
}
