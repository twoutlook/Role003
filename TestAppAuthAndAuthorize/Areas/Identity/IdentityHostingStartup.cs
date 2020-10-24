using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAppAuthAndAuthorize.Data;

[assembly: HostingStartup(typeof(TestAppAuthAndAuthorize.Areas.Identity.IdentityHostingStartup))]
namespace TestAppAuthAndAuthorize.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestAppAuthAndAuthorizeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestAppAuthAndAuthorizeContextConnection")));
            //https://stackoverflow.com/questions/51161729/addidentity-fails-invalidoperationexception-scheme-already-exists-identity
                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<TestAppAuthAndAuthorizeContext>();
            });
        }
    }
}