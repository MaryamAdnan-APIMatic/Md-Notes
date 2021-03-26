// <copyright file="IImplicitOAuthCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Authentication
{
using System;

public interface IImplicitOAuthCredentials
    {
        /// <summary>
        /// Gets oAuthClientId.
        /// </summary>
        string OAuthClientId { get; }

        /// <summary>
        /// Gets oAuthRedirectUri.
        /// </summary>
        string OAuthRedirectUri { get; }

        /// <summary>
        /// Gets oAuthToken.
        /// </summary>
        Models.OAuthToken OAuthToken { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        bool Equals(string oAuthClientId, string oAuthRedirectUri);
    }
}