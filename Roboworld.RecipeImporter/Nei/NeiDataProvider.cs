// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Build all the various disposable things needed to fully load data from NEI files in a zip somewhere
    /// </summary>
    public class NeiDataProvider : INeiDataProvider, IDisposable
    {
        private IList<IDisposable> disposables;

        private NeiCsvParser itemCsvParser;
        private NeiItemPanelCsvParser itemPanelCsvParser;
        private NeiJsonParser itemPanelJsonParser;

        public NeiDataProvider(IFileProvider fileProvider)
        {
            var itemCsvStream = fileProvider.Read("item.csv");
            var itemCsvStreamReader = new StreamReader(itemCsvStream);
            this.itemCsvParser = new NeiCsvParser(itemCsvStreamReader);

            var itemPanelCsvStream = fileProvider.Read("itempanel.csv");
            var itemPanelCsvStreamReader = new StreamReader(itemPanelCsvStream);
            this.itemPanelCsvParser = new NeiItemPanelCsvParser(itemPanelCsvStreamReader);

            var itemPanelJsonStream = fileProvider.Read("itempanel.json");
            var itemPanelJsonStreamReader = new StreamReader(itemPanelJsonStream);
            this.itemPanelJsonParser = new NeiJsonParser(itemPanelJsonStreamReader);

            this.disposables = new List<IDisposable>
                                   {
                                       itemCsvStream,
                                       itemCsvStreamReader,
                                       itemPanelCsvStream,
                                       itemPanelCsvStreamReader,
                                       itemPanelJsonStream,
                                       itemPanelJsonStreamReader
                                   };
        }

        public void Dispose()
        {
            foreach (var disposable in this.disposables)
            {
                disposable.Dispose();
            }

            this.disposables.Clear();
            this.disposables = null;

            this.itemCsvParser.Dispose();
            this.itemCsvParser = null;

            this.itemPanelCsvParser.Dispose();
            this.itemPanelCsvParser = null;

            this.itemPanelJsonParser.Dispose();
            this.itemPanelJsonParser = null;
        }

        public NeiItemsCsvLine ReadItemCsvLine()
        {
            return this.itemCsvParser.ReadLine();
        }

        public NeiItemPanelCsvLine ReadItemPanelCsvLine()
        {
            return this.itemPanelCsvParser.ReadLine();
        }

        public NeiJsonLine ReadItemPanelJsonLine()
        {
            return this.itemPanelJsonParser.ReadLine();
        }
    }
}