// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMineTweakerDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System.Collections.Generic;

    public interface IMineTweakerDataProvider
    {
        IReadOnlyList<string> AllScriptNames();
    }
}