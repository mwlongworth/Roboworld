// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperPackage.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Communication.WebApi.Ioc
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

            var repositoryAssembly = Assembly.GetExecutingAssembly();
            var profileType = typeof(Profile);

            //var registrations =
            //    repositoryAssembly.GetExportedTypes()
            //        .Select(
            //            type =>
            //            new
            //                {
            //                    Implementation = type,
            //                    Services = type.GetInterfaces().Where(o => o.IsAssignableFrom(profileType)).ToList()
            //                })
            //        .Where(o => o.Services.Count > 0)
            //        .ToList();

            //foreach (var reg in registrations)
            //{
            //    foreach (var service in reg.Services)
            //    {
            //        container.Register(service, reg.Implementation, Lifestyle.Transient);
            //    }
            //}

            container.RegisterCollection<Profile>(new[] {Assembly.GetExecutingAssembly()});

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