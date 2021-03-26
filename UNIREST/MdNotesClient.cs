// <copyright file="MdNotesClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using UNIREST.Authentication;
    using UNIREST.Controllers;
    using UNIREST.Http.Client;
    using UNIREST.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class MdNotesClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "http://markdown-notes-app.herokuapp.com" },
                    { Server.Auth, "http://markdown-notes-app.herokuapp.com/oauth" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly ImplicitOAuthManager implicitOAuthManager;

        private readonly Lazy<ServiceController> service;
        private readonly Lazy<UserController> user;

        private MdNotesClient(
            TimeSpan timeout,
            Environment environment,
            string oAuthClientId,
            string oAuthRedirectUri,
            Models.OAuthToken oAuthToken,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Timeout = timeout;
            this.Environment = environment;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.service = new Lazy<ServiceController>(
                () => new ServiceController(this, this.httpClient, this.authManagers));
            this.user = new Lazy<UserController>(
                () => new UserController(this, this.httpClient, this.authManagers));

            if (this.authManagers.ContainsKey("global"))
            {
                this.implicitOAuthManager = (ImplicitOAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.ImplicitOAuthCredentials.Equals(oAuthClientId, oAuthRedirectUri))
            {
                this.implicitOAuthManager = new ImplicitOAuthManager(oAuthClientId, oAuthRedirectUri, oAuthToken, this);
                this.authManagers["global"] = this.implicitOAuthManager;
            }
        }

        /// <summary>
        /// Gets ServiceController controller.
        /// </summary>
        public ServiceController ServiceController => this.service.Value;

        /// <summary>
        /// Gets UserController controller.
        /// </summary>
        public UserController UserController => this.user.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets the credentials to use with ImplicitOAuth.
        /// </summary>
        public IImplicitOAuthCredentials ImplicitOAuthCredentials => this.implicitOAuthManager;

        /// <summary>
        /// Gets Timeout.
        /// Gets the http client timeout.
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Gets Environment.
        /// Gets the Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the MdNotesClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(this.Timeout)
                .Environment(this.Environment)
                .OAuthToken(this.implicitOAuthManager.OAuthToken)
                .ImplicitOAuthCredentials(this.implicitOAuthManager.OAuthClientId, this.implicitOAuthManager.OAuthRedirectUri)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers);

            return builder;
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> MdNotesClient.</returns>
        internal static MdNotesClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("UNIREST_TIMEOUT");
            string environment = System.Environment.GetEnvironmentVariable("UNIREST_ENVIRONMENT");
            string oAuthClientId = System.Environment.GetEnvironmentVariable("UNIREST_O_AUTH_CLIENT_ID");
            string oAuthRedirectUri = System.Environment.GetEnvironmentVariable("UNIREST_O_AUTH_REDIRECT_URI");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (oAuthClientId != null && oAuthRedirectUri != null)
            {
                builder.ImplicitOAuthCredentials(oAuthClientId, oAuthRedirectUri);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        public override string ToString()
        {
            return
                $"Environment = {Environment}, " +
                $"HttpClientConfiguration = {HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(100);
            private Environment environment = UNIREST.Environment.Production;
            private string oAuthClientId = "TODO: Replace";
            private string oAuthRedirectUri = "TODO: Replace";
            private Models.OAuthToken oAuthToken = null;
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private bool createCustomHttpClient = false;
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private IHttpClient httpClient;

            /// <summary>
            /// Sets credentials for ImplicitOAuth.
            /// </summary>
            /// <param name="oAuthClientId">OAuthClientId.</param>
            /// <param name="oAuthRedirectUri">OAuthRedirectUri.</param>
            /// <returns>Builder.</returns>
            public Builder ImplicitOAuthCredentials(string oAuthClientId, string oAuthRedirectUri)
            {
                this.oAuthClientId = oAuthClientId ?? throw new ArgumentNullException(nameof(oAuthClientId));
                this.oAuthRedirectUri = oAuthRedirectUri ?? throw new ArgumentNullException(nameof(oAuthRedirectUri));
                return this;
            }

            /// <summary>
            /// Sets OAuthToken.
            /// </summary>
            /// <param name="oAuthToken">OAuthToken.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthToken(Models.OAuthToken oAuthToken)
            {
                this.oAuthToken = oAuthToken;
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets Timeout.
            /// </summary>
            /// <param name="timeout"> Timeout. </param>
            /// <returns> Builder. </returns>
            public Builder Timeout(TimeSpan timeout)
            {
                this.httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(100) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            /// <summary>
            /// Creates an object of the MdNotesClient using the values provided for the builder.
            /// </summary>
            /// <returns>MdNotesClient.</returns>
            public MdNotesClient Build()
            {
                if (this.createCustomHttpClient)
                {
                    this.httpClient = new HttpClientWrapper(this.httpClientConfig);
                }
                else
                {
                    this.httpClient = new HttpClientWrapper();
                }

                return new MdNotesClient(
                    this.timeout,
                    this.environment,
                    this.oAuthClientId,
                    this.oAuthRedirectUri,
                    this.oAuthToken,
                    this.authManagers,
                    this.httpClient,
                    this.httpClientConfig);
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }
        }
    }
}
