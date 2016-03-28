// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingGuideDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.CraftingGuide
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Build all the various disposable things needed to fully load data from Grafting Guide files
    /// </summary>
    public class CraftingGuideDataProvider : ICraftingGuideDataProvider, IDisposable
    {
        private readonly IFileProvider fileProvider;

        private IList<IDisposable> disposables;

        public CraftingGuideDataProvider(IFileProvider fileProvider)
        {
            if (fileProvider == null) throw new ArgumentNullException(nameof(fileProvider));

            this.fileProvider = fileProvider;
            this.disposables = new List<IDisposable>();
        }

        public void Dispose()
        {
            foreach (var disposable in this.disposables)
            {
                disposable.Dispose();
            }

            this.disposables.Clear();
            this.disposables = null;
        }

        public IReadOnlyList<string> AllModVersions()
        {
            return this.fileProvider.Contents.Where(o => o.EndsWith("mod-version.cg")).ToList();
        }
    }
}