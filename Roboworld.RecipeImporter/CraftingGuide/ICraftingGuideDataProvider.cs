// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICraftingGuideDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.CraftingGuide
{
    using System.Collections.Generic;

    public interface ICraftingGuideDataProvider
    {
        IReadOnlyList<string> AllModVersions();
    }
}