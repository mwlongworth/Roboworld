// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataFilesPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Ioc
{
    using Roboworld.WebApp.Crafting;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class DataFilesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterSingleton<INeiUploader, NeiUploader>();
        }
    }
}