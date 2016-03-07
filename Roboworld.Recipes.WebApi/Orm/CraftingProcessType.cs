// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingProcessType.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public enum CraftingProcessType
    {
        /// <summary>
        /// Value not set correctly
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Standard 3x3 crafting
        /// </summary>
        VanillaCrafting = 1,

        /// <summary>
        /// Standard 3x3 crafting with no shape needed
        /// </summary>
        VanillaShapelessCrafting = 2,

        /// <summary>
        /// Smelt in a furnace
        /// </summary>
        VanillaSmelting = 3,

        /// <summary>
        /// Place into a block and wait (many kinds of processing machines)
        /// </summary>
        BlockProcessing = 3,

        /// <summary>
        /// Place into the world, on top of a block
        /// </summary>
        WorldBlockCrafting = 4,
    }
}