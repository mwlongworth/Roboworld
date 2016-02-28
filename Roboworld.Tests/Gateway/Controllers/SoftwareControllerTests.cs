// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoftwareControllerTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.Gateway.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    using Roboworld.Gateway.WebApi.Controllers;
    using Roboworld.Lua;

    public class SoftwareControllerTests
    {
        private Mock<ILuaRepository> mockLuaRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockLuaRepository = new Mock<ILuaRepository>();
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetWebApiClientFile()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaScriptAsync("webApiClient"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetSoftwareClientFile()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaScriptAsync("softwareClient"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetBootstrapFile()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaScriptAsync("bootstrap"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldCombineFilesTogether()
        {
            this.mockLuaRepository.Setup(o => o.LuaScriptAsync("webApiClient")).ReturnsAsync("a");
            this.mockLuaRepository.Setup(o => o.LuaScriptAsync("softwareClient")).ReturnsAsync("b");
            this.mockLuaRepository.Setup(o => o.LuaScriptAsync("bootstrap")).ReturnsAsync("c");

            var sut = this.BuildDefaultSubjectUnderTest();
            var result = (object)await sut.GetBootstrapper();

            var content = result.Should().BeOfType<OkNegotiatedContentResult<string>>().Subject.Content;
            content.Should().NotBeNull();
            content.Should().Be("a\r\nb\r\nc");
        }

        private SoftwareController BuildDefaultSubjectUnderTest()
        {
            return new SoftwareController(this.mockLuaRepository.Object);
        }
    }
}