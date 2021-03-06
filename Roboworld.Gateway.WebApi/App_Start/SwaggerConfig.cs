﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Swashbuckle.Application;
    using Swashbuckle.Swagger;

    public static class SwaggerConfig
    {
        private const string Description = "LUA-aware endpoint that the in-game robots and computers talk to.  Also allows commands to be queued and pushed back into the game.";

        public static void Register(HttpConfiguration config)
        {
            var assembly = Assembly.GetExecutingAssembly();
            config.EnableSwagger(
                c =>
                    {
                        c.SingleApiVersion("v1", "Gateway Service API").Description(Description);
                        c.RootUrl(req => new Uri(req.RequestUri, req.GetRequestContext().VirtualPathRoot).ToString());
                        c.OperationFilter<JeffFilter>();
                    }).EnableSwaggerUi(
                        c =>
                            {
                                c.InjectStylesheet(assembly, "Roboworld.Gateway.WebApi.Swagger.SwaggerUi.css");
                                c.CustomAsset("images/favicon-16x16-png", assembly, "Roboworld.Gateway.WebApi.Swagger.favicon-16x16-png");
                                c.CustomAsset("images/favicon-32x32-png", assembly, "Roboworld.Gateway.WebApi.Swagger.favicon-32x32-png");
                            });
        }
    }

    public class JeffFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.produces.Add("text/plain");
        }
    }
}