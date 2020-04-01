using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CSGS.Data;
using CSGS.Models;
using CSGS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
namespace CSGS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Indicando la carpeta que va a tener los archivos de recursos
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);




            services.AddAuthorization(
                options => options.AddPolicy("AllowSearch", policy => policy.RequireRole("Admin","Customer","Guest"))

                );

            services.AddAuthorization(
          options => options.AddPolicy("AllowCreate", policy => policy.RequireRole("Customer","Admin"))

          );

            services.AddAuthorization(
                    options => options.AddPolicy("AllowEdit", policy => policy.RequireRole("Admin"))

                    );

            services.AddAuthorization(
                  options => options.AddPolicy("AllowSecurity", policy => policy.RequireRole("Admin"))

                  );

            services.AddAuthorization(
                options => options.AddPolicy("AllowStudents", policy => policy.RequireRole("Customer"))

                );

            services.AddAuthorization(
            options => options.AddPolicy("AllowGuests", policy => policy.RequireRole("Guest"))

            );



            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();



            var cultures = new List<CultureInfo>();
            cultures.Add(new CultureInfo("en-US"));
            cultures.Add(new CultureInfo("fr-FR"));
            cultures.Add(new CultureInfo("es-PE"));

            var requestLocations = new RequestLocalizationOptions
            {
                //Globalization
                SupportedCultures = cultures,
                //Localization
                SupportedUICultures = cultures,
                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
            };

            //Indicando en la aplicacion MVC las culturas que va soportar
            //la aplicacion
            app.UseRequestLocalization(requestLocations);



            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
