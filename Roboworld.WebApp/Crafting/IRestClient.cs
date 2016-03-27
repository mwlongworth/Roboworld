namespace Roboworld.WebApp.Crafting
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IRestClient
    {
        Task SendAsync(HttpMethod method, Uri uri, object data);
    }
}