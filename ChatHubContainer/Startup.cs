﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatHubContainer.Startup))]
namespace ChatHubContainer
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            //app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }

    }
}