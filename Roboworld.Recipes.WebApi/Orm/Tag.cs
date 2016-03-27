// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    /// <summary>
    /// A string representation of a JSON-serialised NBT tag
    /// </summary>
    public class Tag
    {
        public virtual int Id { get; set; }

        public virtual string TagText { get; set; }
    }
}