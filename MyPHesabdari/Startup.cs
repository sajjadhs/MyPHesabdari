using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPHesabdari.Data;
using MyPHesabdari.Model;

namespace MyPHesabdari
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        List<CultureInfo> supportedCultures => new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("fa"),
            new CultureInfo("tr")
        };


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MyDbContext>(q =>
            { //q.UseSqlite("data source=mysd.db");
                q.UseSqlServer(Configuration.GetConnectionString("CN"));

            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
            });

            //adding this as Transiet will stop error in async-await methods
            services.AddTransient<IMyContext, MyDbContext>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.Configure<RequestLocalizationOptions>(options =>
            {
                //options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("fa");
                //      options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            services.AddControllers().AddDataAnnotationsLocalization();
            services.AddRazorPages()
                .AddMvcOptions(w => w.Filters.Add(new AuthorizeFilter()))
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            services.AddServerSideBlazor();


            //q =>
            //{
            //    q.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(v =>
                {
                    v.LoginPath = "/Account/Login";
                    v.LogoutPath = "/Logout";
                })
                .AddCookie("ExternalGoogleAuthentication")
                .AddGoogle(g =>
                {
                   // g.CallbackPath = PathString.FromUriComponent("/Account/index");
                    g.SignInScheme = "ExternalGoogleAuthentication";
                    g.ClientId = Configuration["Google:ClientId"];
                    g.ClientSecret = Configuration["Google:ClientSecret"];
                    g.Scope.Add("profile");
                    g.Scope.Add("openid");
                    g.Scope.Add("email");
                });

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
                app.UseExceptionHandler("/Error");
            }
            app.UseRequestLocalization(options =>
            {
                //options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("fa");
                //      options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
