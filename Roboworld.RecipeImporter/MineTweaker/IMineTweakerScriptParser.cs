// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMineTweakerScriptParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System;

    public interface IMineTweakerScriptParser : IDisposable
    {
        MineTweakerScriptLine ReadNextLine();
    }
}