// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaConvertTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua.Tests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class LuaConvertTests
    {
        [Test]
        public void Serialise_WhenString_ThenIsSerializedCorrectly()
        {
            var value = "Just the string";
            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"""Just the string""");
        }

        [Test]
        public void Serialise_WhenInteger_ThenIsSerializedCorrectly()
        {
            var value = 123;
            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"123");
        }

        [Test]
        public void Serialise_WhenSimpleArray_ThenIsSerializedCorrectly()
        {
            var value = new[] { "Alpha", "Beta", "Gamma" };
            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"{""Alpha"",""Beta"",""Gamma""}");
        }

        [Test]
        public void Serialise_WhenObjectWithProperties_ThenIsSerializedCorrectly()
        {
            var value = new MySimpleObject { ValueOne = "Alpha", ValueTwo = "Beta" };
            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"{ValueOne=""Alpha"",ValueTwo=""Beta""}");
        }

        [Test]
        public void Serialise_WhenCollectionOfConstructables_ThenIsSerializedCorrectly()
        {
            var value = new[] { new Constructable(1, "a"), new Constructable(2, "b") };
            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"{{Number=1,Value=""a""},{Number=2,Value=""b""}}");
        }

        [Test]
        public void Serialise_WhenObjectGraph_ThenIsSerializedCorrectly()
        {
            var value = new MyComplexObject
                            {
                                SimpleOne = new MySimpleObject { ValueOne = "Alpha", ValueTwo = "Beta" },
                                SimpleTwo = new MySimpleObject { ValueOne = "Gamma", ValueTwo = "Delta" },
                            };

            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"{SimpleOne={ValueOne=""Alpha"",ValueTwo=""Beta""},SimpleTwo={ValueOne=""Gamma"",ValueTwo=""Delta""}}");
        }

        [Test]
        public void Serialise_WhenObjectPartialGraph_ThenIsSerializedCorrectly()
        {
            var value = new MyComplexObject { StringCollection = new[] { "One", "Two" } };

            var result = LuaConvert.SerializeObject(value);

            result.Should().Be(@"{StringCollection={""One"",""Two""}}");
        }

        public class MySimpleObject
        {
            public string ValueOne { get; set; }

            public string ValueTwo { get; set; }
        }

        public class Constructable
        {
            public Constructable()
            {
            }

            public Constructable(int number, string value)
            {
                this.Number = number;
                this.Value = value;
            }

            public int Number { get; set; }

            public string Value { get; set; }
        }

        public class MyComplexObject
        {
            public MySimpleObject SimpleOne { get; set; }

            public MySimpleObject SimpleTwo { get; set; }

            public IList<string> StringCollection { get; set; }

            public IList<MySimpleObject> ObjectCollection { get; set; }
        }
    }
}