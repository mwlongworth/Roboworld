// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperTester.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.Testing
{
    using AutoMapper;

    public class AutoMapperTester
    {
        public static IMapper CreateFromProfile<T>() where T : Profile, new()
        {
            var config = new MapperConfiguration(Configure<T>);
            return config.CreateMapper();
        }

        private static void Configure<T>(IMapperConfiguration mapperConfiguration) where T : Profile, new()
        {
            mapperConfiguration.AddProfile(new T());
        }
    }
}