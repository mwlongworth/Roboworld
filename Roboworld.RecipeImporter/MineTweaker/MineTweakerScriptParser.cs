// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerScriptParser.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System.IO;

    public class MineTweakerScriptParser : IMineTweakerScriptParser
    {
        private TextReader reader;

        public MineTweakerScriptParser(TextReader reader)
        {
            this.reader = reader;
        }

        public void Dispose()
        {
            if (this.reader != null)
            {
                this.reader.Dispose();
                this.reader = null;
            }
        }

        public MineTweakerScriptLine ReadNextLine()
        {
            var line = this.reader.ReadLine();
            

            return line == null ? null : new MineTweakerScriptLine(line);
        }
    }
}