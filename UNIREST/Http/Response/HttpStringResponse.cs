// <copyright file="HttpStringResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Http.Response
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using UNIREST.Utilities;

    /// <summary>
    /// HttpStringResponse inherits from HttpResponse and has additional property
    /// of string body.
    /// </summary>
    public sealed class HttpStringResponse : HttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpStringResponse"/> class.
        /// </summary>
        /// <param name="statusCode">statusCode.</param>
        /// <param name="headers">headers.</param>
        /// <param name="rawBody">rawBody.</param>
        /// <param name="body">body.</param>
        public HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body)
        : base(statusCode, headers, rawBody)
        {
            this.Body = body;
        }

        /// <summary>
        /// Gets the raw string body of the http response.
        /// </summary>
        public string Body { get; }

        public override string ToString()
        {
            return $"Body = {Body}" +
                $"{base.ToString()}: ";
        }
    }
}