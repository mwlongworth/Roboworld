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

            var obj = new PutItemRequest();
            var content = new ObjectContent<PutItemRequest>(obj, new JsonMediaTypeFormatter());
            await this.restClient.SendAsync(HttpMethod.Put, uri, content);
        }

        public async Task PutItemVariantAsync(ItemVariant variant)
        {
            var path = string.Format(
                 CultureInfo.InvariantCulture,
                 "http://localhost/Roboworld.Recipes.WebApi/items?mod={0}&name={1}&meta={2}",
                 HttpUtility.UrlEncode(variant.Item.Mod),
                 HttpUtility.UrlEncode(variant.Item.Name),
                 variant.MetaData);

            var uri = new Uri(path);

            var obj = new PutItemVariantRequest();
            var content = new ObjectContent<PutItemVariantRequest>(obj, new JsonMediaTypeFormatter());
            await this.restClient.SendAsync(HttpMethod.Put, uri, content);
        }
    }
}