// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiItemPanelCsvLine.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    public class NeiItemPanelCsvLine
    {
        public string Mod { get; set; }

        public string Name { get; set; }

        public int ItemId { get; set; }

        public int Metadata { get; set; }

        public bool HasNbt { get; set; }

        public string DisplayName { get; set; }
    }
}