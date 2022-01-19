using System;
using Feedback.Areas.Identity.Data;
using Feedback.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Feedback.Areas.Identity.IdentityHostingStartup))]
namespace Feedback.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FeedbackContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FeedbackContextConnection")));

                services.AddDefaultIdentity<FeedbackUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FeedbackContext>();
            });
        }
    }
}