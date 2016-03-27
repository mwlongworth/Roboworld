// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PutItemRequest.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    public class PutItemRequest
    {
        public bool HasBlock { get; set; }

        public int? LegacyId { get; set; }
    }
}