// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileProvider.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// A source for many files
    /// </summary>
    public interface IFileProvider
    {
        IList<string> Contents { get; }

        Stream Read(string path);

        TextReader TextReaderFor(string path);
    }
}