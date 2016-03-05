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
        public async Task Bootstrap_WhenCalled_ShouldGetWebApiClientLibrary()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaLibraryAsync("webApiClient"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetSoftwareClientLibrary()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaLibraryAsync("softwareClient"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetSerializationLibrary()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaLibraryAsync("serialization"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldGetBootstrapScript()
        {
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetBootstrapper();

            this.mockLuaRepository.Verify(o => o.LuaScriptAsync("bootstrap"), Times.Once);
        }

        [Test]
        public async Task Bootstrap_WhenCalled_ShouldCombineFilesTogether()
        {
            this.mockLuaRepository.Setup(o => o.LuaLibraryAsync("webApiClient")).ReturnsAsync("a");
            this.mockLuaRepository.Setup(o => o.LuaLibraryAsync("softwareClient")).ReturnsAsync("b");
            this.mockLuaRepository.Setup(o => o.LuaLibraryAsync("serialization")).ReturnsAsync("c");
            this.mockLuaRepository.Setup(o => o.LuaLibraryAsync("files")).ReturnsAsync("d");
            this.mockLuaRepository.Setup(o => o.LuaScriptAsync("bootstrap")).ReturnsAsync("e");

            var sut = this.BuildDefaultSubjectUnderTest();
            var result = (object)await sut.GetBootstrapper();

            var content = result.Should().BeOfType<OkNegotiatedContentResult<string>>().Subject.Content;
            content.Should().NotBeNull();
            content.Should().Be("a\r\nb\r\nc\r\nd\r\ne");
        }

        [Test]
        public async Task GetLibrary_WhenCalled_ThenShouldLoadCorrectScript()
        {
            var fileId = "aaa";
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetLibrary(fileId);

            this.mockLuaRepository.Verify(o => o.LuaLibraryAsync(fileId), Times.Once);
        }

        [Test]
        public async Task GetScript_WhenCalled_ThenShouldLoadCorrectScript()
        {
            var fileId = "aaa";
            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.GetScript(fileId);

            this.mockLuaRepository.Verify(o => o.LuaScriptAsync(fileId), Times.Once);
        }


        private SoftwareController BuildDefaultSubjectUnderTest()
        {
            return new SoftwareController(this.mockLuaRepository.Object);
        }
    }
}