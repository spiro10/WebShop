using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Mapping;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Implementations;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.Configure<AppSettings>(builder.Configuration);
            //var cfg = builder.Configuration.Get<AppSettings>();

            


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)                
                .AddEntityFrameworkStores<ApplicationDbContext>();



            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICommonService, CommonService>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddRazorPages();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
