// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiItemPanelCsvParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System;
    using System.IO;

    using CsvHelper;

    public class NeiItemPanelCsvParser : IDisposable
    {
        private CsvReader csvReader;

        public NeiItemPanelCsvParser(TextReader textReader)
        {
            if (textReader == null) throw new ArgumentNullException(nameof(textReader));

            this.csvReader = new CsvReader(textReader);
        }

        public NeiItemPanelCsvLine ReadLine()
        {
            if (!this.csvReader.Read()) return null;

            var csvRow = this.csvReader.CurrentRecord;
            var name = csvRow[0].Split(':');
            var displayName = csvRow[4];
            var itemId = int.Parse(csvRow[1]);
            var metadata = int.Parse(csvRow[2]);
            var tasNbt = bool.Parse(csvRow[3]);

            return new NeiItemPanelCsvLine
                       {
                           Mod = name[0],
                           Name = name[1],
                           ItemId = itemId,
                           Metadata = metadata,
                           HasNbt = tasNbt,
                           DisplayName = displayName
                       };
        }

        public void Dispose()
        {
            this.csvReader.Dispose();
            this.csvReader = null;
        }
    }
}