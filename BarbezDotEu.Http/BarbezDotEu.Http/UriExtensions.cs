// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;

namespace BarbezDotEu.Http
{
    /// <summary>
    /// Misc. extensions pertaining to HTTP and URI
    /// </summary>
    public static class HttpUriExtensions
    {
        /// <summary>
        /// Gets a string representing an HTTP URI and returns it as an actual HTTP <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The implicit HTTP URI.</param>
        /// <returns>An HTTP <see cref="Uri"/>.</returns>
        public static Uri GetAsHttpUri(string uri)
        {
            var doesNotNeedPrefixing = uri.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) || uri.StartsWith("https", StringComparison.InvariantCultureIgnoreCase);
            return new Uri(doesNotNeedPrefixing ? uri : "http://" + uri);
        }
    }
}
