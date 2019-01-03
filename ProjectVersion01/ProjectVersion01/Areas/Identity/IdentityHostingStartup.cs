using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectVersion01.Areas.Identity.Data;
using ProjectVersion01.Models;

[assembly: HostingStartup(typeof(ProjectVersion01.Areas.Identity.IdentityHostingStartup))]
namespace ProjectVersion01.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdminContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdminContextConnection")));

                services.AddDefaultIdentity<ProjectVersion01AdminUser>()
                    .AddEntityFrameworkStores<AdminContext>();
            });
        }
    }
}