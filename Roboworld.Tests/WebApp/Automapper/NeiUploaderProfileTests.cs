// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiUploaderProfileTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.WebApp.Automapper
{
    using AutoMapper;

    using FluentAssertions;

    using NUnit.Framework;

    using Roboworld.RecipeImporter;
    using Roboworld.RecipeImporter.Nei;
    using Roboworld.Tests.Testing;
    using Roboworld.WebApp.Ioc;

    public class NeiUploaderProfileTests
    {
        [Test]
        public void Configure_WhenProfileLoaded_ShouldBeValid()
        {
            var sut = BuildDefaultSubjectUnderTest();
            sut.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Map_ConvertNeiItemVariantToVariant_ShouldSucceed()
        {
            var name = "342";
            var sourceItem = new NeiItem {Name = name};
            var sourceVariant = new NeiItemVariant {Item = sourceItem};

            var sut = BuildDefaultSubjectUnderTest();
            var result = sut.Map<NeiItemVariant>(sourceVariant);

            result.Should().NotBeNull();
            result.Item.Name.Should().Be(name);
        }

        private static IMapper BuildDefaultSubjectUnderTest()
        {
            return AutoMapperTester.CreateFromProfile<NeiUploaderProfile>();
        }
    }
}