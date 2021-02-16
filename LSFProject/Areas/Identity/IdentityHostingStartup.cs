using LSFProject.Areas.Identity.Data;
using LSFProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LSFProject.Areas.Identity.IdentityHostingStartup))]
namespace LSFProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LSFContext>(options =>
                    options.UseSqlServer(Config.ConnectionString));

                services.AddDefaultIdentity<LSFUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<LSFContext>();

                services.AddAuthorization(options => {
                    options.AddPolicy("readpolicy",
                        builder => builder.RequireRole("Admin", "Manager", "User"));
                    options.AddPolicy("writepolicy",
                        builder => builder.RequireRole("Admin", "Manager"));
                });
            });
        }
    }
}