// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingProcess.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public class CraftingProcess
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual CraftingProcessType Type { get; set; }

        public virtual Item Item { get; set; }

        public virtual bool Deleted { get; set; }
    }
}