// <copyright file="IHttpClientConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Http.Client
{
    using System;

    /// <summary>
    /// Represents the current state of the Http Client.
    /// </summary>
    public interface IHttpClientConfiguration
    {
        /// <summary>
        /// Gets the Http client timeout.
        /// </summary>
        TimeSpan Timeout { get; }
    }
}
