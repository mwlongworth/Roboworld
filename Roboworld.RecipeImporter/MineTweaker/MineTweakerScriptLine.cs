// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MineTweakerScriptLine.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter.MineTweaker
{
    using System;
    using System.Text.RegularExpressions;

    public class MineTweakerScriptLine
    {
        private static readonly Regex CommentRegex = new Regex(@"^(#.*)|(//.*)$");
        private static readonly Regex CommandRegex = new Regex(@"^(.*)\.\w+\(.*\);$");
        private static readonly Regex VariableRegex = new Regex(@"^val (\w*)\s*=\s*(.+);$");
        private static readonly Regex PrintRegex = new Regex(@"^print\(.*\);$");

        public MineTweakerScriptLine(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            this.Line = line;
            this.Type = GetLineType(line);
        }

        private static MineTweakerLineType GetLineType(string line)
        {
            if (CommentRegex.IsMatch(line))
            {
                return MineTweakerLineType.Comment;
            }

            if (CommandRegex.IsMatch(line))
            {
                return MineTweakerLineType.Command;
            }

            if (VariableRegex.IsMatch(line))
            {
                return MineTweakerLineType.Variable;
            }

            if (PrintRegex.IsMatch(line))
            {
                return MineTweakerLineType.Print;
            }

            return MineTweakerLineType.Unknown;
        }

        public string Line { get; set; }

        public MineTweakerLineType Type { get; set; }
    }
}