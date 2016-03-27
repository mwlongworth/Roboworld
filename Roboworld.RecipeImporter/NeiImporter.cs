// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiImporter.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class NeiImporter : INeiImporter
    {
        private readonly IFileProvider fileProvider;

        private HashSet<NeiItem> allItems;

        public NeiImporter(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public IReadOnlyList<NeiItem> GetAllItems()
        {
            var items = new List<NeiItem>();

            using (var itemStream = this.fileProvider.Read("item.csv"))
            using (var reader = new StreamReader(itemStream))
            using (var csv = new CsvHelper.CsvReader(reader))
            {
                while (csv.Read())
                {
                    var row = csv.CurrentRecord;
                    var name = row[0].Split(':');
                    var itemId = int.Parse(row[1]);
                    var item = new NeiItem { Mod = name[0], Name = name[1], ItemId = itemId };
                    items.Add(item);
                }
            }

            this.allItems = new HashSet<NeiItem>(items);

            return items;
        }

        public IReadOnlyList<NeiItemVariant> GetAllItemVariants()
        {
            var variants = new List<NeiItemVariant>();

            using (var csvStream = this.fileProvider.Read("itempanel.csv"))
            using (var jsonStream = this.fileProvider.Read("itempanel.json"))
            using (var csvReader = new StreamReader(csvStream))
            using (var jsonReader = new StreamReader(jsonStream))
            using (var csv = new CsvHelper.CsvReader(csvReader))
            {
                var json = new NeiJsonParser(jsonReader);
                while (csv.Read())
                {
                    var csvRow = csv.CurrentRecord;
                    var jsonRow = json.ReadLine();
                    var name = csvRow[0].Split(':');
                    var displayName = csvRow[4];
                    var itemId = int.Parse(csvRow[1]);
                    var metadata = int.Parse(csvRow[2]);

                    var key = new NeiItem { Mod = name[0], Name = name[1], ItemId = itemId };
                    if (!this.allItems.Contains(key))
                    {
                        var msg = string.Format(
                            CultureInfo.InvariantCulture,
                            "Cannot find {0} in the items collection",
                            key);
                        throw new InvalidOperationException(msg);
                    }

                    var variant = new NeiItemVariant { Item = key, Metadata = metadata, DisplayName = displayName };

                    variants.Add(variant);
                }
            }


            return variants;
        }
    }
}