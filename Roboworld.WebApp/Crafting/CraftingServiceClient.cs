// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingServiceClient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System;
    using System.Net.Http;

    public class CraftingServiceClient : ICraftingServiceClient
    {
        private readonly HttpClient httpClient;

        public CraftingServiceClient(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;
        }
    }
}