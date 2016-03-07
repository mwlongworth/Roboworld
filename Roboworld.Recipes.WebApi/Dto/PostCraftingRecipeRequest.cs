// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostCraftingRecipeRequest.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Dto
{
    using System.Collections.Generic;

    public class PostCraftingRecipeRequest
    {
        public string Process { get; set; }

        public IReadOnlyList<Ingredient> Ingredients { get; set; }

        public int Quantity { get; set; }

        public IReadOnlyList<int> Shape { get; set; }
    }

    public class Ingredient
    {
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public bool Catalyst { get; set; }
    }
}