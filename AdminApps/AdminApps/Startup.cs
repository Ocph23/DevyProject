﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminApps.Startup))]
namespace AdminApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
