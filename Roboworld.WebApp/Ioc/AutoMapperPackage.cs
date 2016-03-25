// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Ioc
{
    using System.Collections.Generic;
    using System.Reflection;

    using AutoMapper;

    using SimpleInjector;
    using SimpleInjector.Packaging;

    public class AutoMapperPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<Profile>(new[] { Assembly.GetExecutingAssembly() });

            container.RegisterSingleton(
                () => new MapperConfiguration(c => Init(c, container.GetAllInstances<Profile>())));
            container.RegisterSingleton(() => container.GetInstance<MapperConfiguration>().CreateMapper());
        }

        private static void Init(IConfiguration mapperConfiguration, IEnumerable<Profile> profiles)
        {
            foreach (var profile in profiles)
            {
                mapperConfiguration.AddProfile(profile);
            }
        }
    }
}