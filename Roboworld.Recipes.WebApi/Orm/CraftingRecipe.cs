// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipe.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    using System.Collections.Generic;

    public class CraftingRecipe
    {
        public virtual int Id { get; set; }

        public virtual Mod Mod { get; set; }

        public virtual CraftingProcess Process { get; set; }

        public virtual Item Output { get; set; }

        public virtual int Quantity { get; set; }

        public virtual IList<RecipeIngredient> Ingredients { get; set; }

        public virtual bool Deleted { get; set; }
    }
}