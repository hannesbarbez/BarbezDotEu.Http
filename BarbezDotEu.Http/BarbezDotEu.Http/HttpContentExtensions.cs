// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BarbezDotEu.Http
{
    /// <summary>
    /// Misc. extensions pertaining to <see cref="HttpContent"/>.
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Converts <see cref="HttpContent"/> to textual string content, even if GZipped.
        /// </summary>
        /// <param name="httpContent">The <see cref="HttpContent"/> to convert.</param>
        /// <returns>A string representation of the given <see cref="HttpContent"/>.</returns>
        public static async Task<string> GetAsTextAsync(this HttpContent httpContent)
        {
            var text = string.Empty;
            if (httpContent.IsContentGZip())
            {
                using (var outputStream = new MemoryStream())
                {
                    var input = httpContent.ReadAsStreamAsync().Result;
                    using (var inputStream = new GZipStream(input, CompressionMode.Decompress))
                    {
                        inputStream.CopyTo(outputStream); // Decompress input to output.
                        outputStream.Flush(); // Make sure all bytes are written.
                    }
                    outputStream.Position = 0;

                    if (httpContent.IsContentUtf8())
                    {
                        text = Encoding.UTF8.GetString(outputStream.ToArray());
                    }
                    else
                    {
                        using (StreamReader streamReader = new StreamReader(outputStream))
                        {
                            text = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            else
            {
                text = await httpContent.ReadAsStringAsync();
            }
            return text;
        }

        /// <summary>
        /// Checks if <see cref="HttpContent"/> is GZipped and if so, returns true.
        /// </summary>
        /// <param name="httpContent">The <see cref="HttpContent"/> to check.</param>
        /// <returns>True if GZipped.</returns>
        public static bool IsContentGZip(this HttpContent httpContent)
        {
            return httpContent.Headers.ContentEncoding.Any(x => string.Equals(x, StringConstants.AcceptEncodingGzip, StringComparison.InvariantCultureIgnoreCase))
                || (httpContent.Headers.ContentType != null && string.Equals(httpContent.Headers.ContentType.MediaType, StringConstants.ApplicationGzip, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Checks if <see cref="HttpContent"/> is UTF8 and if so, returns true.
        /// </summary>
        /// <param name="httpContent">The <see cref="HttpContent"/> to check.</param>
        /// <returns>True if the content is UTF8.</returns>
        public static bool IsContentUtf8(this HttpContent httpContent)
        {
            return string.Equals(httpContent.Headers.ContentType.CharSet, StringConstants.UTF8, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
