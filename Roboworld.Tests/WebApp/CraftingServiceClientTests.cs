// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingServiceClientTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.WebApp
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    using Roboworld.WebApp.Crafting;

    [TestFixture]
    [Category("Unit")]
    public class CraftingServiceClientTests
    {
        private Mock<IRestClient> mockRestClient;

        [SetUp]
        public void SetUp()
        {
            this.mockRestClient = new Mock<IRestClient> { DefaultValue = DefaultValue.Mock };
        }

        [Test]
        public void Constructor_WhenSomeParameterIsNull_ThenThrowsArgumentNull()
        {
            Action act = () => new CraftingServiceClient(null);
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("restClient");
        }

        [Test]
        public async Task Send_WhenModContainsSlash_ShouldUrlEncodeCorrectly()
        {
            var item = new Item
            {
                Mod = "mod/name",
                Name = "foobar"
            };

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutItemAsync(item);

            this.mockRestClient.Verify(
                o =>
                o.SendAsync(It.IsAny<HttpMethod>(), It.Is<Uri>(c => c.ToString().Contains("mod=mod%2fname")), It.IsAny<object>()),
                Times.Once);
        }

        [Test]
        public async Task Send_WhenWhenNameContainsSlash_ShouldUrlEncodeCorrectly()
        {
            var item = new Item
                           {
                               Mod = "mod",
                               Name = "foo/bar"
                           };

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutItemAsync(item);

            this.mockRestClient.Verify(
                o =>
                o.SendAsync(It.IsAny<HttpMethod>(), It.Is<Uri>(c => c.ToString().Contains("name=foo%2fbar")), It.IsAny<object>()),
                Times.Once);
        }


        private CraftingServiceClient BuildDefaultSubjectUnderTest()
        {
            return new CraftingServiceClient(mockRestClient.Object);
        }
    }
}