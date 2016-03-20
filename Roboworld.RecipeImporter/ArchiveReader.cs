// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchiveReader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    /// <summary>
    /// Read an zip file into a bunch of files
    /// </summary>
    public class ArchiveReader : IFileProvider, IDisposable
    {
        private ZipArchive archive;

        public ArchiveReader(Stream stream)
        {
            this.archive = new ZipArchive(stream, ZipArchiveMode.Read);

            this.Contents = this.archive.Entries.Select(o => o.FullName).ToList();
        }

        public IList<string> Contents { get; private set; }

        public Stream Read(string path)
        {
            return this.archive.GetEntry(path).Open();
        }


        public void Dispose()
        {
            if (this.archive != null)
            {
                this.archive.Dispose();
                this.archive = null;
            }
        }
    }
}