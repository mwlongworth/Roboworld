﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleInjectorConfig.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi
{
    using System.Reflection;
    using System.Web.Http;

    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;

    public static class SimpleInjectorConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterPackages(new[] { Assembly.GetExecutingAssembly() });

            container.Verify();

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}