// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICraftingServiceClient.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System.Threading.Tasks;

    public interface ICraftingServiceClient
    {
        Task PutItemAsync(Item item);

        Task PutItemVariantAsync(ItemVariant variant);
    }
}