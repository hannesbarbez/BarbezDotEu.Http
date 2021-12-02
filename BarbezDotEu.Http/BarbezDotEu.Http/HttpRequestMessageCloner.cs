// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BarbezDotEu.Http
{
    /// <summary>
    /// Helper class for cloning <see cref="HttpRequestMessage"/>s.
    /// </summary>
    public static class HttpRequestMessageCloner
    {
        /// <summary>
        /// Clones a given <see cref="HttpRequestMessage"/>.
        /// 
        /// Using this method helps avoiding a "The request message was already sent. Cannot send the same request message multiple times." InvalidOperationException.
        /// 
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/a/46026230
        /// </remarks>
        public static async Task<HttpRequestMessage> Clone(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = await CloneHttpContent(request.Content),
                Version = request.Version
            };

            foreach (var header in request.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            return clone;
        }

        /// <summary>
        /// Clones given <see cref="HttpContent"/>.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/a/46026230
        /// </remarks>
        private static async Task<HttpContent> CloneHttpContent(HttpContent content)
        {
            if (content == null) return null;
            var memoryStream = new MemoryStream();
            await content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var clone = new StreamContent(memoryStream);
            foreach (var header in content.Headers)
                clone.Headers.Add(header.Key, header.Value);

            return clone;
        }
    }
}
