// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi
{
    using System;
    using System.Net.Http;
    using System.Web.Http;

    using Swashbuckle.Application;

    public static class SwaggerConfig
    {
        private const string Description = "Serves all recipies for a given server (including all the various processing types)";

        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(
              c =>
              {
                  c.SingleApiVersion("v1", "Resource Service API").Description(Description);
                  c.RootUrl(req => new Uri(req.RequestUri, req.GetRequestContext().VirtualPathRoot).ToString());
              }).EnableSwaggerUi();
        }
    }
}