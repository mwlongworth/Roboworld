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

        public virtual IList<RecipeContent> Contents { get; set; }

        public virtual bool Deleted { get; set; }
    }
}