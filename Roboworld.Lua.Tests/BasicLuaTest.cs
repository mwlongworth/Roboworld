// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicLuaTest.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua.Tests
{
    using FluentAssertions;

    using Neo.IronLua;

    using NUnit.Framework;

    [TestFixture]
    public class BasicLuaTest
    {
        private readonly IResourceLoader loader = new EmbeddedResourceLoader<LuaLibrary>();

        [Test]
        public void Table_WhenTableReturned_IsValid()
        {
            var sut = this.BuildDefaultSubjectUnderTest("serialization");

            var result = sut.ExecuteString("output({1,\"two\",\"3\"})");

            var table = result.Should().BeOfType<LuaTable>().Subject;
            table.Length.Should().Be(3);
        }

        [Test]
        public void TableValuesToJson_WhenTableReturned_IsValid()
        {
            var sut = this.BuildDefaultSubjectUnderTest("serialization");

            var result = sut.ExecuteString("output(tableValuesToJson({1,\"two\",\"3\"}))");

            var table = result.Should().BeOfType<string>().Subject;
            table.Should().Be("[1,\"two\",\"3\"]");
        }

        [Test]
        public void TablePairsToJson_WhenTableReturned_IsValid()
        {
            var sut = this.BuildDefaultSubjectUnderTest("serialization");

            var result = sut.ExecuteString(@"
local myTable = {}
myTable.integer = 1
myTable.string = ""two""
myTable.stringnumber = ""3""

output(tablePairsToJson(myTable))");

            var table = result.Should().BeOfType<string>().Subject;
            table.Should().Be("{\"integer\":1,\"string\":\"two\",\"stringnumber\":\"3\"}");
        }

        private LuaRunner BuildDefaultSubjectUnderTest(params string[] filenames)
        {
            return new LuaRunner(this.loader).AddLibraries(filenames);
        }
    }
}
