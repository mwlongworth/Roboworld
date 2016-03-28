// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INeiDataProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    /// <summary>
    /// Read data out of an archive containing NEI files
    /// </summary>
    public interface INeiDataProvider
    {
        NeiItemsCsvLine ReadItemCsvLine();

        NeiItemPanelCsvLine ReadItemPanelCsvLine();

        NeiJsonLine ReadItemPanelJsonLine();
    }
}