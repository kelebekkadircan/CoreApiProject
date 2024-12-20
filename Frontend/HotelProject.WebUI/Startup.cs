using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<Context>();
        //    services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
        //    services.AddHttpClient();
        //    services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
        //    services.AddControllersWithViews().AddFluentValidation();
        //    services.AddAutoMapper(typeof(Startup));

        //}
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext ve Identity yap�land�rmas�
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            // HttpClient servisi ekleniyor
            services.AddHttpClient();

            // FluentValidation konfig�rasyonu
            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();

            // FluentValidation i�in Validator s�n�f� ekleniyor
            services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
            services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

            // Controller ve View yap�land�rmas�
            services.AddControllersWithViews();

            // AutoMapper yap�land�rmas�
            services.AddAutoMapper(typeof(Startup));
            
            services.AddMvc(
               config =>
               {
                   var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                                     config.Filters.Add(new AuthorizeFilter(policy));
               } 
                );
            services.ConfigureApplicationCookie(
                options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = "/Login/Index";
                    

                }

                );
        
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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
