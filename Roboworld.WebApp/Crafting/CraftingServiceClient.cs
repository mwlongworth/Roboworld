// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingServiceClient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    public class CraftingServiceClient : ICraftingServiceClient
    {
        private readonly HttpClient httpClient;

        public CraftingServiceClient(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;
        }

        public async Task PutItemAsync(Item item)
        {
            var path = string.Format(
                CultureInfo.InvariantCulture,
                "http://localhost/Roboworld.Recipes.WebApi/items/{0}/{1}",
                item.Mod,
                item.Name);

            var uri = new Uri(path);

            var obj = new PutItemRequest();
            var content = new ObjectContent<PutItemRequest>(obj, new JsonMediaTypeFormatter());
            await this.httpClient.PutAsync(uri, content);
        }

        public Task PutItemVariantAsync(ItemVariant item)
        {
            return Task.FromResult(0);
        }
    }

    public class PutItemRequest
    {
        
    }
}