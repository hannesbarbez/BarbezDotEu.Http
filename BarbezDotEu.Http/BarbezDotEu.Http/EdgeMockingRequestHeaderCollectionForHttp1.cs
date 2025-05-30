﻿// Copyright (c) Hannes Barbez. All rights reserved.
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
    public class EdgeMockingRequestHeaderCollectionForHttp1
    {
        /// <summary>
        /// Gets an Edge style user agent header.
        /// </summary>
        public const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.0.0 Safari/537.36 Edg/136.0.0.0";

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
        /// Gets an Edge style cache-control header.
        /// </summary>
        public CacheControlHeaderValue CacheControl { get; }

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
            httpRequestMessage.Headers.CacheControl = this.CacheControl;
            httpRequestMessage.Headers.Pragma.Add(this.Pragma);
            httpRequestMessage.Headers.Connection.Add(this.Connection);
            httpRequestMessage.Headers.Add("User-Agent", UserAgent);
            httpRequestMessage.Headers.Host = this.Host;

            foreach (var header in this.Others)
                httpRequestMessage.Headers.Add(header.Key, header.Value);

            return httpRequestMessage;
        }

        /// <summary>
        /// Gets an Edge style pragma header.
        /// </summary>
        public NameValueHeaderValue Pragma { get; }

        /// <summary>
        /// Gets a collection of non-standard headers, including:
        /// - Edge style do-not-track header;
        /// - Edge style sec-fetch-site header;
        /// - Edge style sec-fetch-mode header;
        /// - Edge style sec-fetch-dest header.
        /// </summary>
        public KeyValuePair<string, string>[] Others { get; }

        /// <summary>
        /// Gets an Edge style connection header.
        /// </summary>
        public string Connection { get; }

        /// <summary>
        /// Gets the hostname.
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Constructs a new <see cref="EdgeMockingRequestHeaderCollectionForHttp2"/>.
        /// </summary>
        /// <param name="referrer">The referrer to set.</param>
        /// <param name="host">The value to set for the host header. Defaults to the domain of the referrer, if none provided.</param>
        public EdgeMockingRequestHeaderCollectionForHttp1(string referrer, string host = null)
        {
            var acceptHeaderJson = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
            var acceptHeaderText = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Plain);
            var acceptHeaderAnything = new MediaTypeWithQualityHeaderValue("*/*");

            AcceptHeaders = [acceptHeaderJson, acceptHeaderText, acceptHeaderAnything];
            this.AcceptLanguage = new StringWithQualityHeaderValue("en-US", 0.9);
            this.Referrer = new Uri(referrer);
            this.CacheControl = new CacheControlHeaderValue() { NoCache = true };
            this.Pragma = new NameValueHeaderValue("pragma", "no-cache");
            this.Connection = "keep-alive";

            this.Others =
            [
                new KeyValuePair<string, string>("Sec-Fetch-Site","same-site"),
                new KeyValuePair<string, string>("Sec-Fetch-Mode","cors"),
                new KeyValuePair<string, string>("Sec-Fetch-Dest","empty"),
                new KeyValuePair<string, string>("DNT","1"),
            ];

            DetermineAndSetHost(host);
        }

        /// <summary>
        /// Determines and sets the value of the host header. Defaults to the domain of the referrer, if no meaningful host name is provided.
        /// </summary>
        /// <param name="host"></param>
        private void DetermineAndSetHost(string host)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                this.Host = this.Referrer.Host;
            }
            else
            {
                this.Host = host;
            }
        }
    }
}
