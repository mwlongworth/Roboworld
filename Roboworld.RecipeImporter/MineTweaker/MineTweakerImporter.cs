// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerImporter.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System;
    using System.Text;

    using Roboworld.WebApp.Crafting;

    public class MineTweakerImporter
    {
        private readonly IMineTweakerDataProvider provider;

        private readonly IMineTweakerUploader uploader;

        public MineTweakerImporter(IMineTweakerDataProvider provider, IMineTweakerUploader uploader)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (uploader == null) throw new ArgumentNullException(nameof(uploader));

            this.provider = provider;
            this.uploader = uploader;
        }

        public string Import()
        {
            var sb = new StringBuilder();
            while (this.provider.ReadNextScript())
            {
                MineTweakerScriptLine line;
                while ((line = this.provider.CurrentParser.ReadNextLine()) != null)
                {
                    if(line.Type == MineTweakerLineType.Unknown)
                    sb.AppendLine(line.Line);
                }
            }

            return sb.ToString();
        }
    }
}