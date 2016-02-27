// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Roboworld.Gateway.WebApi;

[assembly: Microsoft.Owin.OwinStartup(typeof(Startup))]

namespace Roboworld.Gateway.WebApi
{
    using System.Web.Http;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            SimpleInjectorConfig.Register(config);
            WebApiConfig.Register(config);
            SwaggerConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}