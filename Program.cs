<<<<<<< HEAD
namespace MVC_APP
=======
namespace ASP.Net_application
>>>>>>> 3c6afcb428f0332b8b2c5313f58fa69a4c820f37
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
<<<<<<< HEAD
            builder.Services.AddControllersWithViews();
=======
            builder.Services.AddRazorPages();
>>>>>>> 3c6afcb428f0332b8b2c5313f58fa69a4c820f37

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
<<<<<<< HEAD
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
=======
                app.UseExceptionHandler("/Error");
            }
>>>>>>> 3c6afcb428f0332b8b2c5313f58fa69a4c820f37
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
<<<<<<< HEAD
            //app.MapRazorPages();  -- withou controller this how pages are added 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
=======

            app.MapRazorPages();
>>>>>>> 3c6afcb428f0332b8b2c5313f58fa69a4c820f37

            app.Run();
        }
    }
}