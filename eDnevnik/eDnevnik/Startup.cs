using AutoMapper;
using eDnevnik.Controllers;
using eDnevnik.Helper;
using eDnevnik.Interfaces;
using eDnevnik.Service;
using eDnevnik.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeminarskiRS1.Model;

namespace eDnevnik
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

            // smtp login data 
            services.Configure<SmtpConfig>(x =>
            {
                x.Email = Configuration["SmtpPodaci:userName"];
                x.Password = Configuration["SmtpPodaci:password"];
            });

            // sms api keys 
            services.Configure<SmsConfig>(x =>
            {
                x.ApiKey = Configuration["SmsPodaci:Nexmo.api_key"];
                x.ApiSecret = Configuration["SmsPodaci:Nexmo.api_secret"];
                x.BrojTelefonaPosiljaoca = Configuration["SmsPodaci:NEXMO_FROM_NUMBER"];
            });

            // DB Connection
            services.AddDbContext<DataBaseContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("pleskDb")));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataBaseContext>()
            //    .AddDefaultTokenProviders();
         
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            // auto mapper extension
            services.AddAutoMapper(typeof(Startup));

            // dependency injection
            services.AddScoped<INastavnoOsobljeService, NastavnoOsobljeService>();
            services.AddScoped<ILogiraniKorisnikService, LogiraniKorisnikService>();

            services.AddTransient<SessionController>();
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
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
