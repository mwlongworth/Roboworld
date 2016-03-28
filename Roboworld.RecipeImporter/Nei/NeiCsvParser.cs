// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiCsvParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    using System;
    using System.IO;

    using CsvHelper;

    public class NeiCsvParser : IDisposable
    {
        private CsvReader csvReader;

        public NeiCsvParser(TextReader textReader)
        {
            if (textReader == null) throw new ArgumentNullException(nameof(textReader));

            this.csvReader = new CsvReader(textReader);
        }

        public NeiItemsCsvLine ReadLine()
        {
            if (!this.csvReader.Read()) return null;

            var row = this.csvReader.CurrentRecord;
            var name = row[0].Split(':');
            var itemId = int.Parse(row[1]);
            return new NeiItemsCsvLine { Mod = name[0], Name = name[1], ItemId = itemId };
        }

        public void Dispose()
        {
            this.csvReader.Dispose();
            this.csvReader = null;
        }
    }
}