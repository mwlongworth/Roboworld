// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultRoute",
            //    routeTemplate: "{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional });
        }
    }
}