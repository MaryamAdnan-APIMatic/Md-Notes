// <copyright file="OAuthProviderException.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using UNIREST;
    using UNIREST.Http.Client;
    using UNIREST.Models;
    using UNIREST.Utilities;

    /// <summary>
    /// OAuthProviderException.
    /// </summary>
    public class OAuthProviderException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthProviderException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public OAuthProviderException(string reason, HttpContext context)
            : base(reason, context) { }


        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("error", ItemConverterType = typeof(StringEnumConverter))]
        public Models.OAuthProviderErrorEnum Error { get; set; }

        /// <summary>
        /// Human-readable text providing additional information on error.
        /// Used to assist the client developer in understanding the error that occurred.
        /// </summary>
        [JsonProperty("error_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// A URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error
        /// </summary>
        [JsonProperty("error_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorUri { get; set; }
    }
}