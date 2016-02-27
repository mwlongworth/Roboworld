// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi
{
    using System;
    using System.Net.Http;
    using System.Web.Http;

    using Swashbuckle.Application;

    public static class SwaggerConfig
    {
        private const string Description = "LUA-aware endpoint that the in-game robots and computers talk to.  Also allows commands to be queued and pushed back into the game.";

        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(
              c =>
              {
                  c.SingleApiVersion("v1", "Gateway Service API").Description(Description);
                  c.RootUrl(req => new Uri(req.RequestUri, req.GetRequestContext().VirtualPathRoot).ToString());
              }).EnableSwaggerUi();
        }
    }
}