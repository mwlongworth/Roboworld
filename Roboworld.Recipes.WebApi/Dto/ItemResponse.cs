// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemResponse.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Dto
{
    public class ItemResponse
    {
        public virtual int Id { get; set; }

        public virtual string ModSlug { get; set; }

        public virtual string Slug { get; set; }
    }
}