// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemVariant.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Orm
{
    public class ItemVariant
    {
        public virtual int Id { get; set; }

        public virtual Item Item { get; set; }

        public virtual int Metadata { get; set; }

        public virtual string TagText { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual bool Deleted { get; set; }
    }
}