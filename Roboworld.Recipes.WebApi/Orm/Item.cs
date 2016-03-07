// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public class Item
    {
        public virtual int Id { get; set; }

        public virtual string Slug { get; set; }

        public virtual string Name { get; set; }

        public virtual Mod Mod { get; set; }

        public virtual bool Deleted { get; set; }
    }
}