// <copyright file="HttpClientConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Http.Client
{
    using System;

    /// <summary>
    /// Represents the current state of the Http Client.
    /// </summary>
    internal class HttpClientConfiguration : IHttpClientConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientConfiguration"/> class.
        /// </summary>
        public HttpClientConfiguration()
        {
            this.Timeout = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Gets the Http client timeout.
        /// </summary>
        public TimeSpan Timeout { get; internal set; }

        public override string ToString()
        {
            return "HttpClientConfiguration: " +
                $"{Timeout} ";
        }
    }
}
