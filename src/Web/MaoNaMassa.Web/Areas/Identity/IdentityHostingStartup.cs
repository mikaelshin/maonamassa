﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MaoNaMassa.Web.Areas.Identity.IdentityHostingStartup))]

namespace MaoNaMassa.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
