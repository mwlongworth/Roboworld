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
    using System.Web;

    public class CraftingServiceClient : ICraftingServiceClient
    {
        private readonly IRestClient restClient;

        public CraftingServiceClient(IRestClient restClient)
        {
            if (restClient == null) throw new ArgumentNullException(nameof(restClient));

            this.restClient = restClient;
        }

        public async Task PutItemAsync(Item item)
        {
            var path = string.Format(
                CultureInfo.InvariantCulture,
                "http://localhost/Roboworld.Recipes.WebApi/items?mod={0}&name={1}",
                HttpUtility.UrlEncode(item.Mod),
                HttpUtility.UrlEncode(item.Name));

            var uri = new Uri(path);

            var data = new PutItemRequest();
            await this.restClient.SendAsync(HttpMethod.Put, uri, data);
        }

        public async Task PutItemVariantAsync(ItemVariant variant)
        {
            var path = string.Format(
                 CultureInfo.InvariantCulture,
                 "http://mattl-pc/Roboworld.Recipes.WebApi/items/variant?mod={0}&name={1}&meta={2}",
                 HttpUtility.UrlEncode(variant.Item.Mod),
                 HttpUtility.UrlEncode(variant.Item.Name),
                 variant.MetaData);

            var uri = new Uri(path);

            var data = new PutItemVariantRequest
                          {
                              DisplayName = variant.DisplayName,
                              TagText = variant.TagText
                          };
            await this.restClient.SendAsync(HttpMethod.Put, uri, data);
        }
    }
}