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
            this.CreateMap<Dto.CreateItemDto, Item>()
                .IgnoreAllUnmapped();
            this.CreateMap<Dto.PutItemRequest, Item>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Mod, o => o.Ignore())
                .ForMember(d => d.Slug, o => o.Ignore())
                .ForMember(d => d.Deleted, o => o.Ignore());

            this.CreateMap<Dto.PutItemVariantRequest, ItemVariant>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Item, o => o.Ignore())
                .ForMember(d => d.Metadata, o => o.Ignore())
                .ForMember(d => d.Deleted, o => o.Ignore());

            this.CreateMap<Item, Dto.ItemResponse>();
            this.CreateMap<ItemVariant, Dto.ItemVariantResponse>();
        }
    }
}