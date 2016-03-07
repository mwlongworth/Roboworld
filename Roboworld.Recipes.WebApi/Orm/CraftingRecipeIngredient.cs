// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeIngredient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public class CraftingRecipeIngredient
    {
        public virtual int Id { get; set; }

        public virtual CraftingRecipe CraftingRecipe { get; set; }

        public virtual Item Item { get; set; }

        public virtual int Ordinal { get; set; }

        public virtual int Quantity { get; set; }

        public virtual bool Catalyst { get; set; }
    }
}