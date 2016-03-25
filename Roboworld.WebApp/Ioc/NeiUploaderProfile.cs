// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiUploaderProfile.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Ioc
{
    using AutoMapper;

    using Roboworld.RecipeImporter;
    using Roboworld.WebApp.Crafting;

    public class NeiUploaderProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<NeiItem, Item>();
            this.CreateMap<NeiItemVariant, ItemVariant>();
        }
    }
}