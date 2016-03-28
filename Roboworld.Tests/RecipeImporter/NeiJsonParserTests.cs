// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiJsonParserTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.RecipeImporter
{
    using System;
    using System.IO;

    using FluentAssertions;

    using NUnit.Framework;

    using Roboworld.RecipeImporter.Nei;

    [TestFixture]
    [Category("Unit")]
    public class NeiJsonParserTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Constructor_WhenSomeParameterIsNull_ThenThrowsArgumentNull()
        {
            Action act = () => new NeiJsonParser(null);
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("jsonReader");
        }

        [Test]
        public void ReadLine_WhenLineHasMetadata_ThenIsReadCorrectly()
        {
            const string Content = "{id:6s,Damage:4s}";

            var sut = this.BuildDefaultSubjectUnderTest(Content);
            var result = sut.ReadLine();

            result.Should().NotBeNull();
            result.ItemId.Should().Be(6);
            result.Metadata.Should().Be(4);
            result.TagText.Should().BeNull();
        }

        [Test]
        public void ReadLine_WhenLineHasNoTag_ThenIsReadCorrectly()
        {
            const string Content = "{id:301s,Damage:0s}";

            var sut = this.BuildDefaultSubjectUnderTest(Content);
            var result = sut.ReadLine();

            result.Should().NotBeNull();
            result.ItemId.Should().Be(301);
        }

        [Test]
        public void ReadLine_WhenLineHasTag_ThenIsReadCorrectly()
        {
            const string Content = "{id:6752s,tag:{species:\"rootFlowers\",chromosome:2,allele:\"botany.colorGoldenrod\"},Damage:0s}";

            var sut = this.BuildDefaultSubjectUnderTest(Content);
            var result = sut.ReadLine();

            result.Should().NotBeNull();
            result.ItemId.Should().Be(6752);
            result.Metadata.Should().Be(0);
            result.TagText.Should().NotBeNull();
        }

        [Test]
        public void ReadLine_WhenLineHasTagWithNumericLiteralSuffixes_ThenIsReadCorrectly()
        {
            const string Content = "{id:6999s,tag:{internalMaxPower:1600000.0d,internalCurrentPower:1600000.0d},Damage:0s}";

            var sut = this.BuildDefaultSubjectUnderTest(Content);
            var result = sut.ReadLine();

            result.Should().NotBeNull();
            result.ItemId.Should().Be(6999);
            result.Metadata.Should().Be(0);
            result.TagText.Should().Be("{internalMaxPower:1600000.0d,internalCurrentPower:1600000.0d}");
        }


        [Test]
        public void ReadLine_WhenLineHasTagWithMultiLines_ThenIsReadCorrectly()
        {
            const string Content = "{id:6999s,tag:{internalMaxPower:1600000.0d\r\n,internalCurrentPower:1600000.0d},Damage:0s}";

            var sut = this.BuildDefaultSubjectUnderTest(Content);
            var result = sut.ReadLine();

            result.Should().NotBeNull();
            result.ItemId.Should().Be(6999);
            result.Metadata.Should().Be(0);
            result.TagText.Should().Be("{internalMaxPower:1600000.0d,internalCurrentPower:1600000.0d}");
        }

        private NeiJsonParser BuildDefaultSubjectUnderTest(string content)
        {
            return new NeiJsonParser(new StringReader(content));
        }
    }
}