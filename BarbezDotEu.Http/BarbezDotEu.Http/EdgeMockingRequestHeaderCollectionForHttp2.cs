// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

namespace BarbezDotEu.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;

    /// <summary>
    /// Mocks headers that would've been sent typically by Microsoft Edge during the last quarter of 2024.
    /// </summary>
    public class EdgeMockingRequestHeaderCollectionForHttp2
    {
        /// <summary>
        /// Gets an Edge style user agent header.
        /// </summary>
        /// <remarks>
        /// Needs to align with SecChUa.
        /// </remarks>
        public const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.0.0 Safari/537.36 Edg/136.0.0.0";

        /// <summary>
        /// Gets the Edge style Sec-Ch-Ua header.
        /// </summary>
        /// <remarks>
        /// Needs to align with UserAgent.
        /// </remarks>
        public const string SecChUa = "\"Chromium\";v=\"136\", \"Microsoft Edge\";v=\"136\", \"Not.A/Brand\";v=\"99\"";

        /// <summary>
        /// Gets the Edge style Sec-Ch-Ua header.
        /// </summary>
        public const string SecChUaMobile = "?0";

        /// <summary>
        /// Gets the Edge style Sec-Ch-Ua header.
        /// </summary>
        public const string SecChUaPlatform = "\"Windows\"";

        /// <summary>
        /// Gets Edge style accept headers.
        /// </summary>
        public MediaTypeWithQualityHeaderValue[] AcceptHeaders { get; }

        /// <summary>
        /// Gets an Edge style accept header.
        /// </summary>
        public StringWithQualityHeaderValue AcceptLanguage { get; }

        /// <summary>
        /// Gets an Edge style referrer header.
        /// </summary>
        public Uri Referrer { get; }

        /// <summary>
        /// Gets the origin header value.
        /// </summary>
        public string Origin { get; }

        /// <summary>
        /// Gets a collection of non-standard headers
        /// </summary>
        public KeyValuePair<string, string>[] Others { get; }

        /// <summary>
        /// Prepares a given <see cref="HttpRequestMessage"/> with headers sent typically by Microsoft Edge during the first half of 2021.
        /// </summary>
        /// <param name="httpRequestMessage">The <see cref="HttpRequestMessage"/> to adjust.</param>
        public HttpRequestMessage Prep(HttpRequestMessage httpRequestMessage)
        {
            foreach (var acceptHeader in this.AcceptHeaders)
                httpRequestMessage.Headers.Accept.Add(acceptHeader);

            httpRequestMessage.Headers.AcceptLanguage.Add(this.AcceptLanguage);
            httpRequestMessage.Headers.Referrer = this.Referrer;
            httpRequestMessage.Headers.Add("User-Agent", UserAgent);
            if (this.Origin != null)
                httpRequestMessage.Headers.Add("Origin", this.Origin);

            foreach (var header in this.Others)
                httpRequestMessage.Headers.Add(header.Key, header.Value);

            return httpRequestMessage;
        }

        /// <summary>
        /// Constructs a new <see cref="EdgeMockingRequestHeaderCollectionForHttp2"/>.
        /// </summary>
        /// <param name="referrer">The referrer to set.</param>
        /// <param name="origin">The origin to set.</param>
        public EdgeMockingRequestHeaderCollectionForHttp2(string referrer, string origin = null)
        {
            var acceptHeaderJson = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
            var acceptHeaderText = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Plain);
            var acceptHeaderAnything = new MediaTypeWithQualityHeaderValue("*/*");
            if (origin != null)
                Origin = origin;

            this.AcceptHeaders = [acceptHeaderJson, acceptHeaderText, acceptHeaderAnything];
            this.AcceptLanguage = new StringWithQualityHeaderValue("en-US", 0.9);
            this.Referrer = new Uri(referrer);
            this.Others =
            [
                new KeyValuePair<string, string>("Sec-Fetch-Site", "same-site"),
                new KeyValuePair<string, string>("Sec-Fetch-Mode", "cors"),
                new KeyValuePair<string, string>("Sec-Fetch-Dest", "empty"),
                new KeyValuePair<string, string>("DNT", "1"),
                new KeyValuePair<string, string>("Priority", "u=1, i"),
                new KeyValuePair<string, string>("Sec-CH-UA", SecChUa),
                new KeyValuePair<string, string>("Sec-CH-UA-Mobile", SecChUaMobile),
                new KeyValuePair<string, string>("Sec-CH-UA-Platform", SecChUaPlatform),
            ];
        }
    }
}
