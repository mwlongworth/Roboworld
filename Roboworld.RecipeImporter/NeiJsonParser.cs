// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiJsonParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Because it doesn't seem to really be json?
    /// </summary>
    public class NeiJsonParser : IDisposable
    {
        private static Regex noTagRegex = new Regex("^{id:(?<i>\\d+)s,Damage:(?<m>\\d+)s}$");

        private static Regex tagRegex = new Regex("^{id:(?<i>\\d+)s,tag:(?<t>.*),Damage:(?<m>\\d+)s}$");

        private TextReader jsonReader;

        public NeiJsonParser(TextReader jsonReader)
        {
            if (jsonReader == null) throw new ArgumentNullException(nameof(jsonReader));
            this.jsonReader = jsonReader;
        }

        public NeiJsonLine ReadLine()
        {
            var line = this.jsonReader.ReadLine();

            var match = tagRegex.Match(line);
            if (!match.Success) match = noTagRegex.Match(line);
            if (!match.Success)
            {
                return null;
            }

            return ParseMatch(match);
        }

        private static NeiJsonLine ParseMatch(Match match)
        {
            var itemId = int.Parse(match.Groups["i"].Value);
            var metaData    = int.Parse(match.Groups["m"].Value);

            var tagText = match.Groups["t"].Value;

            return new NeiJsonLine
                       {
                           ItemId = itemId,
                           Metadata = metaData,
                           TagText = string.IsNullOrEmpty(tagText) ? null : tagText
                       };
        }

        public void Dispose()
        {
            this.jsonReader = null;
        }
    }
}