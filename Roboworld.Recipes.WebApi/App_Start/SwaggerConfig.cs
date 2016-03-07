// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;

    using Swashbuckle.Application;

    public static class SwaggerConfig
    {
        private const string Description = "Serves all recipies for a given server (including all the various processing types)";

        public static void Register(HttpConfiguration config)
        {
            var assembly = Assembly.GetExecutingAssembly();
            config.EnableSwagger(
              c =>
              {
                  c.SingleApiVersion("v1", "Recipes Service API").Description(Description);
                  c.RootUrl(req => new Uri(req.RequestUri, req.GetRequestContext().VirtualPathRoot).ToString());
              }).EnableSwaggerUi(
                        c =>
                        {
                            c.InjectStylesheet(assembly, "Roboworld.Recipes.WebApi.Swagger.SwaggerUi.css");
                            c.CustomAsset("images/favicon-16x16-png", assembly, "Roboworld.Recipes.WebApi.Swagger.favicon-16x16-png");
                            c.CustomAsset("images/favicon-32x32-png", assembly, "Roboworld.Recipes.WebApi.Swagger.favicon-32x32-png");
                        });
        }
    }
}