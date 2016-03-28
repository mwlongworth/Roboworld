// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Build all the various disposable things needed to fully load data from MineTweaker files
    /// </summary>
    public class MineTweakerDataProvider : IMineTweakerDataProvider, IDisposable
    {
        private readonly IFileProvider fileProvider;

        private IList<IDisposable> disposables;

        public MineTweakerDataProvider(IFileProvider fileProvider)
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

        public IReadOnlyList<string> AllScriptNames()
        {
            return this.fileProvider.Contents.Where(o => o.EndsWith(".zs")).ToList();
        }
    }
}