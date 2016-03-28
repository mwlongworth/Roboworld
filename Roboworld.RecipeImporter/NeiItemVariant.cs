// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiItemVariant.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    public class NeiItemVariant
    {
        public NeiItem Item { get; set; }

        public int Metadata { get; set; }

        public string DisplayName { get; set; }

        public string TagText { get; set; }
    }
}