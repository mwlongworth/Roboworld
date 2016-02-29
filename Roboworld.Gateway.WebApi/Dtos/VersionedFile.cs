// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionedFile.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Dtos
{
    using System.Globalization;

    public class VersionedFile
    {
        public VersionedFile(string name, int major, int minor, int revision)
        {
            this.Name = name;
            this.Version = string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}", major, minor, revision);
        }

        public string Name { get; set; }

        public string Version { get; set; }
    }
}