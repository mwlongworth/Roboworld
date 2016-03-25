// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiUploader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.WebApp.Crafting
{
    using System;

    public class NeiUploader : INeiUploader
    {
        private readonly ICraftingServiceClient craftingServiceClient;

        public NeiUploader(ICraftingServiceClient craftingServiceClient)
        {
            if (craftingServiceClient == null) throw new ArgumentNullException(nameof(craftingServiceClient));

            this.craftingServiceClient = craftingServiceClient;
        }
    }
}