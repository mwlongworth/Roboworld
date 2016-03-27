// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiUploader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using Roboworld.RecipeImporter;

    public class NeiUploader : INeiUploader
    {
        private readonly ICraftingServiceClient craftingServiceClient;
        private readonly IMapper mapper;

        public NeiUploader(ICraftingServiceClient craftingServiceClient, IMapper mapper)
        {
            if (craftingServiceClient == null) throw new ArgumentNullException(nameof(craftingServiceClient));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));

            this.craftingServiceClient = craftingServiceClient;
            this.mapper = mapper;
        }

        public async Task UploadItemsAsync(IReadOnlyList<NeiItem> items)
        {
            foreach (var neiItem in items)
            {
                var item = this.mapper.Map<Item>(neiItem);
                await this.craftingServiceClient.PutItemAsync(item);
            }       
        }

        public async Task UploadVariantsAsync(IReadOnlyList<NeiItemVariant> variants)
        {
            return; // Disabled for now

            foreach (var neiVariant in variants)
            {
                var variant = this.mapper.Map<ItemVariant>(neiVariant);
                await this.craftingServiceClient.PutItemVariantAsync(variant);
            }
        }
    }
}