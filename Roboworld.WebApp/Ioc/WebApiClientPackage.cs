// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiClientPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Ioc
{
    using System.Net.Http;

    using Roboworld.WebApp.Crafting;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class WebApiClientPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterSingleton(() => new HttpClient());
            container.RegisterSingleton<IRestClient, RestClient>();
            container.RegisterSingleton<ICraftingServiceClient, CraftingServiceClient>();
        }
    }
}