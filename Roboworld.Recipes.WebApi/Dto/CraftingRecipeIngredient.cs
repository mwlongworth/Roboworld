// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeIngredient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Dto
{
    public class CraftingRecipeIngredient
    {
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public bool Catalyst { get; set; }
    }
}