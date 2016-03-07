// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mod.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    using System.Collections.Generic;

    public class Mod
    {
        public virtual int Id { get; set; }

        public virtual string Slug { get; set; }

        public virtual string Version { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Item> Items { get; set; }

        public virtual bool Deleted { get; set; }
    }
}