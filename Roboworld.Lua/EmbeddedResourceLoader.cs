// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmbeddedResourceLoader.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    public class EmbeddedResourceLoader : IResourceLoader
    {
        private readonly Assembly assembly;

        private readonly string rootNamespace;

        public EmbeddedResourceLoader()
        {
            this.assembly = Assembly.GetExecutingAssembly();
            this.rootNamespace = typeof(EmbeddedResourceLoader).Namespace;
        }

        public string LoadResource(string name)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", this.rootNamespace, name);
            var stream = this.assembly.GetManifestResourceStream(fullName);

            if (stream == null)
            {
                throw new InvalidOperationException("No such file");
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}