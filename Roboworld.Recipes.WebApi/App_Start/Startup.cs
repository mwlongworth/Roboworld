// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

[assembly: Microsoft.Owin.OwinStartup(typeof(Roboworld.Recipes.WebApi.Startup))]

namespace Roboworld.Recipes.WebApi
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