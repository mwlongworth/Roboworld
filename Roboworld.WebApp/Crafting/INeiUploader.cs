// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INeiUploader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Roboworld.RecipeImporter.Nei;

    public interface INeiUploader
    {
        Task UploadItemsAsync(IReadOnlyList<NeiItem> items);

        Task UploadVariantsAsync(IReadOnlyList<NeiItemVariant> variants);
    }
}