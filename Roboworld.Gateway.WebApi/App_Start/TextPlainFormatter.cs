// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextPlainFormatter.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Gateway.WebApi
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class TextPlainFormatter : MediaTypeFormatter
    {
        public TextPlainFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }

        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger)
        {
            return Task.Run(() => Read(readStream));
        }

        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext,
            CancellationToken cancellationToken)
        {
            var allBytes = Encoding.UTF8.GetBytes(value.ToString());
            return writeStream.WriteAsync(allBytes, 0, allBytes.Length, cancellationToken);
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }

        private static object Read(Stream readStream)
        {
            var memoryStream = new MemoryStream();
            readStream.CopyTo(memoryStream);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}