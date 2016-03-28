// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INeiImporter.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    using System.Collections.Generic;

    public interface INeiImporter
    {
        IReadOnlyList<NeiItem> GetAllItems();
    }
}