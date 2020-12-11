using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatStacks.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace MatStacks
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

         //  services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));

            services.AddDbContext<SubjectDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("SubjectDataContext");

                options.UseSqlServer(connectionString);
            });
            
            services.AddDbContext<ExerciseSubjectDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("ExerciseSubjectDataContext");

                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();

            services.AddDbContext<IdentityDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("IdentityDataContext");

                options.UseSqlServer(connectionString);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIdentity();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
