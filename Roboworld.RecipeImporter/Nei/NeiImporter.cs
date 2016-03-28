// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiImporter.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    using System;
    using System.Collections.Generic;

    public class NeiImporter : INeiImporter
    {
        private readonly INeiDataProvider fileProvider;

        public NeiImporter(INeiDataProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public IReadOnlyList<NeiItem> GetAllItems()
        {
            var items = new List<NeiItem>();
            NeiItemsCsvLine line;

            while ((line = this.fileProvider.ReadItemCsvLine()) != null)
            {
                items.Add(new NeiItem { Mod = line.Mod, Name = line.Name, ItemId = line.ItemId });
            }

            return items;
        }

        public IReadOnlyList<NeiItemVariant> GetAllItemVariants()
        {
            var variants = new List<NeiItemVariant>();
            NeiItemPanelCsvLine line;

            while ((line = this.fileProvider.ReadItemPanelCsvLine()) != null)
            {
                // The JSON file can be read from the 
                var jsonLine = this.fileProvider.ReadItemPanelJsonLine();

                var jsonIsValid = AssertLinesMatch(line, jsonLine);
                var key = new NeiItem { Mod = line.Mod, Name = line.Name, ItemId = line.ItemId };

                var variant = new NeiItemVariant
                                  {
                                      Item = key,
                                      Metadata = line.Metadata,
                                      DisplayName = line.DisplayName,
                                      TagText = jsonIsValid ? jsonLine.TagText : null
                                  };

                variants.Add(variant);
            }

            return variants;
        }

        private static bool AssertLinesMatch(NeiItemPanelCsvLine line, NeiJsonLine jsonLine)
        {
            if (jsonLine == null)
            {
                throw new InvalidOperationException("Could not find a json line");
            }

            if (jsonLine.ItemId != line.ItemId)
            {
                throw new InvalidOperationException("Missmatch on item Id");
            }

            if (jsonLine.Metadata != line.Metadata)
            {
                return false;
            }

            return true;
        }
    }
}