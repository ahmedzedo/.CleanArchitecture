using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureSample.Application.Packages.Services;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using CleanArchitectureSample.Domain.Interfaces.IUnitOfWorks;
using CleanArchitectureSample.Persistence.EF;
using CleanArchitectureSample.Persistence.EF.Repositories;
using CleanArchitectureSample.Persistence.EF.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitectureSample.Presentation.UI.Web
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
            services.AddDbContext<DbContext, TestContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("Test")));
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageConfigFileRepository, PackageConfigFileRepository>();
            services.AddScoped<ITerminalPackageRepository, TerminalPackageRepository>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddScoped<IPackageUnitOfWork, PackageUnitOfWork>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddRazorPages();
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
