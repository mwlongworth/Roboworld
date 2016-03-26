// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PutItemRequest.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Dto
{
    public class PutItemRequest
    {
        public virtual bool HasBlock { get; set; }

        public virtual int? LegacyId { get; set; }
    }
}