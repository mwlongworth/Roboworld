// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoMappingProfile.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Ioc
{
    using AutoMapper;

    public class DtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            //this.CreateMap<Dto.CreateItemDto, Item>();
        }
    }
}