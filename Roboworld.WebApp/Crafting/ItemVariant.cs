// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemVariant.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    public class ItemVariant
    {
        public Item Item { get; set; }

        public int MetaData { get; set; }

        public object Tag { get; set; }

        public string DisplayName { get; set; }
    }
}