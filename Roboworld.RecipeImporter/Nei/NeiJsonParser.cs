// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NeiJsonParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.Nei
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Because it doesn't seem to really be JSON?
    /// </summary>
    public class NeiJsonParser : IDisposable
    {
        private static Regex noTagRegex = new Regex("^{id:(?<i>\\d+)s,Damage:(?<m>\\d+)s}$");

        private static Regex tagRegex = new Regex("^{id:(?<i>\\d+)s,tag:(?<t>[\\S\\s]*),Damage:(?<m>\\d+)s}$");

        private TextReader jsonReader;

        public NeiJsonParser(TextReader jsonReader)
        {
            if (jsonReader == null) throw new ArgumentNullException(nameof(jsonReader));
            this.jsonReader = jsonReader;
        }

        public NeiJsonLine ReadLine()
        {
            var match = this.ReadLinesUntilMatch();

            return ParseMatch(match);
        }

        private Match ReadLinesUntilMatch()
        {
            var sb = new StringBuilder();
            Match match;
            do
            {
                var line = this.jsonReader.ReadLine();
                if (line == null)
                {
                    throw new InvalidOperationException("EOF?");
                }

                sb.Append(line);
                match = tagRegex.Match(sb.ToString());
                if (!match.Success)
                {
                    match = noTagRegex.Match(line);
                }
            }
            while (!match.Success);

            return match;
        }

        private static NeiJsonLine ParseMatch(Match match)
        {
            var itemId = int.Parse(match.Groups["i"].Value);
            var metaData = int.Parse(match.Groups["m"].Value);

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