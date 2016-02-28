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
    using System.Threading.Tasks;

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
            using (var stream = this.assembly.GetManifestResourceStream(fullName))
            {
                if (stream == null)
                {
                    var msg = string.Format(
                        CultureInfo.InvariantCulture,
                        "Unable to load '{0}' from the assembly {1}",
                        fullName,
                        this.assembly.FullName);
                    throw new InvalidOperationException(msg);
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public Task<string> LoadResourceAsync(string name)
        {
            var fullName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", this.rootNamespace, name);
            using (var stream = this.assembly.GetManifestResourceStream(fullName))
            {
                if (stream == null)
                {
                    var msg = string.Format(
                        CultureInfo.InvariantCulture,
                        "Unable to load '{0}' from the assembly {1}",
                        fullName,
                        this.assembly.FullName);
                    throw new InvalidOperationException(msg);
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEndAsync();
                }
            }
        }
    }
}