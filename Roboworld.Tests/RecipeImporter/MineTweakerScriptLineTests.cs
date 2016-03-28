// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerScriptLineTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.RecipeImporter
{
    using System;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    using Roboworld.RecipeImporter.MineTweaker;

    [TestFixture]
    [Category("Unit")]
    public class MineTweakerScriptLineTests
    {
      

        [Test]
        public void Constructor_WhenSomeParameterIsNull_ThenThrowsArgumentNull()
        {
            Action act = () => new MineTweakerScriptLine(null);
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("line");
        }

        [Test]
        public void Constructor_WhenLineIsHashComment_ShouldIdentifyTypeAsComment()
        {
            var sut = new MineTweakerScriptLine("#Name: 1-InitialScripts.zs");
            sut.Type.Should().Be(MineTweakerLineType.Comment);
        }

        [Test]
        public void Constructor_WhenLineIsDoubleSlashComment_ShouldIdentifyTypeAsComment()
        {
            var sut = new MineTweakerScriptLine("//NEI.hide(<ThaumicTinkerer:darkQuartz>);");
            sut.Type.Should().Be(MineTweakerLineType.Comment);
        }

        [Test]
        public void Constructor_WhenLineIsCommand_ShouldIdentifyTypeAsCommand()
        {
            var sut = new MineTweakerScriptLine("NEI.hide(<Botania:livingwood1SlabFull>);");
            sut.Type.Should().Be(MineTweakerLineType.Command);
        }

        [Test]
        public void Constructor_WhenLineIsVariableAssignment_ShouldIdentifyTypeAsVariable()
        {
            var sut = new MineTweakerScriptLine("val dyeOrange = <ore:dyeOrange>;");
            sut.Type.Should().Be(MineTweakerLineType.Variable);
        }

        [Test]
        public void Constructor_WhenLineIsPrint_ShouldIdentifyTypeAsPrint()
        {
            var sut = new MineTweakerScriptLine("print(\"Initialized '1-InitialScripts.zs'\");");
            sut.Type.Should().Be(MineTweakerLineType.Print);
        }
    }
}