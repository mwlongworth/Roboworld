// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingServiceClient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CraftingServiceClient : ICraftingServiceClient
    {
        private readonly HttpClient httpClient;

        public CraftingServiceClient(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;
        }

        public Task PutItemAsync(Item item)
        {
            return Task.FromResult(0);
        }

        public Task PutItemVariantAsync(ItemVariant item)
        {
            return Task.FromResult(0);
        }
    }
}