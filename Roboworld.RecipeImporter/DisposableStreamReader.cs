// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisposableStreamReader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.RecipeImporter
{
    using System.IO;

    public class DisposableStreamReader : StreamReader
    {
        private Stream stream;

        public DisposableStreamReader(Stream stream) : base(stream)
        {
            this.stream = stream;
        }

        public new void Dispose()
        {
            if (this.stream != null)
            {
                this.stream.Dispose();
                this.stream = null;
            }

            base.Dispose();
        }
    }
}