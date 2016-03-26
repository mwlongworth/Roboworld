// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Ioc
{
    using Roboworld.Recipes.WebApi.Persistance;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class RepositoryPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IItemsRepository, ItemsRepository>(Lifestyle.Scoped);
        }
    }
}