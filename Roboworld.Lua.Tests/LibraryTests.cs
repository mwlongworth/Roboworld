// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LibraryTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua.Tests
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class LibraryTests
    {
        private readonly ILuaRepository repository = new LuaRepository();

        [TestCase("web")]
        [TestCase("software")]
        [TestCase("serialization")]
        [TestCase("files")]
        public void Library_WhenLoadedFromAssembly_ShouldBeValidLua(string libraryName)
        {
            var sut = this.BuildDefaultSubjectUnderTest(libraryName);
            var result = sut.ExecuteString("output(\"yes\")");
            result.Should().Be("yes");
        }

        private LuaRunner BuildDefaultSubjectUnderTest(params string[] filenames)
        {
            return new LuaRunner(this.repository).AddLibraries(filenames);
        }
    }
}
