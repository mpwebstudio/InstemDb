using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InstemDb.Data;
using InstemDb.Infrastructure;
using InstemDb.Services.Infrastructure;
using InstemDb.Services;
using InstemDb.Services.Implementation;

namespace InstemDb
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
            services
                .AddDbContext<InstemDbContext>(options => options
                    .UseSqlServer(Configuration.GetDefaultConnectionString()));

            services
                .AddDefaultIdentity<IdentityUser>(options => options
                    .SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<InstemDbContext>();

            services.AddAutoMapper(typeof(CarouselServiceMappingProfile));

            services
                .AddControllersWithViews(options => options
                    .AddAutoValidateAntiforgeryToken())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services
                .AddTransient<ICarouselService, CarouselService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IInfoService, InfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints();

            app.SeedData();
        }
    }
}
