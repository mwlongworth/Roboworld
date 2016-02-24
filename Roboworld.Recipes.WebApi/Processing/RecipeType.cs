// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeType.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Processing
{
    public enum RecipeType
    {
        Unknown = 0,

        /// <summary>
        /// Normal vanilla 3x3 crafting grid
        /// </summary>
        Crafting = 1,

        /// <summary>
        /// Add a bunch of inputs, and get an output
        /// </summary>
        SimpleMachine = 2,

        /// <summary>
        /// Bees
        /// </summary>
        Bees = 3
    }
}