// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestClient.cs" company="Matthew Longworth">
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

    public class RestClient : IRestClient
    {
        private readonly HttpClient httpClient;

        public RestClient(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;
        }

        public async Task SendAsync(HttpMethod method, Uri uri, object data)
        {
            var obj = new PutItemRequest();
            var content = new ObjectContent<PutItemRequest>(obj, new JsonMediaTypeFormatter());
            var result = await this.httpClient.PutAsync(uri, content).ConfigureAwait(false);

            if (!result.IsSuccessStatusCode)
            {
                //var errorContent = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                var msg = string.Format(
                    CultureInfo.InvariantCulture,
                    "HTTP {0} when accessing {1}",
                    result.StatusCode,
                    uri);
                throw new HttpRequestException(msg);
            }
        }
    }
}