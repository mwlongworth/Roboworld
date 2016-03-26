// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoMappingProfileTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.Crafting.Automapper
{
    using AutoMapper;

    using NUnit.Framework;

    using Roboworld.Recipes.WebApi.Ioc;
    using Roboworld.Tests.Testing;

    public class DtoMappingProfileTests
    {
        [Test]
        public void Configure_WhenProfileLoaded_ShouldBeValid()
        {
            var sut = BuildDefaultSubjectUnderTest();
            sut.ConfigurationProvider.AssertConfigurationIsValid();
        }

        private static IMapper BuildDefaultSubjectUnderTest()
        {
            return AutoMapperTester.CreateFromProfile<DtoMappingProfile>();
        }
    }
}