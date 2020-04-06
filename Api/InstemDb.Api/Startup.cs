using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InstemDb.Data;
using InstemDb.Services.Infrastructure;
using InstemDb.Services;
using InstemDb.Services.Implementation;
using InstemDb.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace InstemDb.Api
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
            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.UseApiBehavior = false;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "vVVV";
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "v2";
                document.ApiGroupNames = new[] { "2" };
                document.IgnoreObsoleteProperties = true;
            })
                .AddSwaggerDocument(document =>
                {
                    document.DocumentName = "v1";
                    document.ApiGroupNames = new[] { "1" };
                });

            services
                .AddDbContext<InstemDbContext>(options => options
                    .UseSqlServer(Configuration.GetDefaultConnectionString()));

            services
                .AddDefaultIdentity<IdentityUser>(options => options
                    .SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<InstemDbContext>();

            services.AddAutoMapper(typeof(CarouselServiceMappingProfile));

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
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
