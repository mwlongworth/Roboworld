// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoMappingProfile.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Ioc
{
    using AutoMapper;

    using Roboworld.Recipes.WebApi.Orm;

    public class DtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Dto.CreateItemDto, Item>();
        }
    }
}