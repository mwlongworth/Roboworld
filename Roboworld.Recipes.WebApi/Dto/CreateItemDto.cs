// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateItemDto.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class CreateItemDto
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual int Mod { get; set; }
    }
}