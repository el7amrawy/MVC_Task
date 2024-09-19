using MVCTask.Models;

namespace MVCTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages().AddSessionStateTempDataProvider();

            services.AddControllersWithViews();
            //services.AddControllersWithViews().AddSessionStateTempDataProvider();

            //services.AddSession(options => {
            //    options.IdleTimeout=TimeSpan.FromMinutes(15);
            //});

            services.AddSqlServer<Day6MvcdbContext>(connectionString: "name=ConnectionStrings:local");
        }
    }
}
