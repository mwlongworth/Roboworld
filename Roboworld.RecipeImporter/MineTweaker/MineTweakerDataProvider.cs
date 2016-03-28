// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Build all the various disposable things needed to fully load data from MineTweaker files
    /// </summary>
    public class MineTweakerDataProvider : IMineTweakerDataProvider, IDisposable
    {
        private readonly IFileProvider fileProvider;

        private readonly Queue<string> scriptNames;

        private IList<IDisposable> disposables;

        private TextReader currentReader;

        public MineTweakerDataProvider(IFileProvider fileProvider)
        {
            if (fileProvider == null) throw new ArgumentNullException(nameof(fileProvider));

            this.fileProvider = fileProvider;
            this.disposables = new List<IDisposable>();

            var scripts = this.fileProvider.Contents.Where(o => o.EndsWith(".zs"));
            this.scriptNames = new Queue<string>(scripts);
        }

        public IMineTweakerScriptParser CurrentParser { get; private set; }

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
            return scriptNames.ToList();
        }

        public bool ReadNextScript()
        {
            if (this.scriptNames.Count == 0)
            {
                return false;
            }

            var nextScriptPath = this.scriptNames.Dequeue();
            if (this.CurrentParser != null)
            {
                this.CurrentParser.Dispose();
            }

            if (this.currentReader != null)
            {
                this.currentReader.Dispose();
            }

            var reader = this.fileProvider.TextReaderFor(nextScriptPath);
            this.CurrentParser = new MineTweakerScriptParser(reader);
            this.currentReader = reader;

            return true;
        }
    }
}