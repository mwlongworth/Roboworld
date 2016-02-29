// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdatableSoftware.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi.Dtos
{
    using System.Collections.Generic;

    public class UpdatableSoftware
    {
        public IList<VersionedFile> Libraries { get; set; }

        public IList<VersionedFile> Scripts { get; set; }
    }
}