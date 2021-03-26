// <copyright file="OAuthToken.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Models
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
    using UNIREST.Utilities;

    /// <summary>
    /// OAuthToken.
    /// </summary>
    public class OAuthToken : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthToken"/> class.
        /// </summary>
        public OAuthToken()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthToken"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="expiresIn">expires_in.</param>
        /// <param name="scope">scope.</param>
        /// <param name="expiry">expiry.</param>
        public OAuthToken(
            string accessToken,
            string tokenType,
            long? expiresIn = null,
            string scope = null,
            long? expiry = null)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.ExpiresIn = expiresIn;
            this.Scope = scope;
            this.Expiry = expiry;
        }

        /// <summary>
        /// Access token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Type of access token
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Time in seconds before the access token expires
        /// </summary>
        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// List of scopes granted
        /// This is a space-delimited list of strings.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        /// <summary>
        /// Time of token expiry as unix timestamp (UTC)
        /// </summary>
        [JsonProperty("expiry", NullValueHandling = NullValueHandling.Ignore)]
        public long? Expiry { get; set; }
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OAuthToken : ({string.Join(", ", toStringOutput)})";
        }

        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccessToken = {(AccessToken == null ? "null" : AccessToken == string.Empty ? "" : AccessToken)}");
            toStringOutput.Add($"TokenType = {(TokenType == null ? "null" : TokenType == string.Empty ? "" : TokenType)}");
            toStringOutput.Add($"ExpiresIn = {(ExpiresIn == null ? "null" : ExpiresIn.ToString())}");
            toStringOutput.Add($"Scope = {(Scope == null ? "null" : Scope == string.Empty ? "" : Scope)}");
            toStringOutput.Add($"Expiry = {(Expiry == null ? "null" : Expiry.ToString())}");

            base.ToString(toStringOutput);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is OAuthToken other &&
                ((AccessToken == null && other.AccessToken == null) || (AccessToken?.Equals(other.AccessToken) == true)) &&
                ((TokenType == null && other.TokenType == null) || (TokenType?.Equals(other.TokenType) == true)) &&
                ((ExpiresIn == null && other.ExpiresIn == null) || (ExpiresIn?.Equals(other.ExpiresIn) == true)) &&
                ((Scope == null && other.Scope == null) || (Scope?.Equals(other.Scope) == true)) &&
                ((Expiry == null && other.Expiry == null) || (Expiry?.Equals(other.Expiry) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -746518720;

            if (AccessToken != null)
            {
               hashCode += AccessToken.GetHashCode();
            }

            if (TokenType != null)
            {
               hashCode += TokenType.GetHashCode();
            }

            if (ExpiresIn != null)
            {
               hashCode += ExpiresIn.GetHashCode();
            }

            if (Scope != null)
            {
               hashCode += Scope.GetHashCode();
            }

            if (Expiry != null)
            {
               hashCode += Expiry.GetHashCode();
            }

            return hashCode;
        }
    }
}