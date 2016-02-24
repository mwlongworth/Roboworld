// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeContent.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public class RecipeContent
    {
        public virtual int Id { get; set; }

        public virtual CraftingRecipe Name { get; set; }

        public virtual int Ordinal { get; set; }

        public virtual Item Item { get; set; }
    }
}