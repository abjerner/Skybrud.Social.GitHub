using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Models.Authentication;
using Skybrud.Social.GitHub.Scopes;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the GitHub API as well as any OAuth 2.0
    /// communication/authentication.
    /// </summary>
    public class GitHubOAuthClient : SocialHttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The GitHub API support basic authentication, so even though this is not a part of OAuth, the
        /// <code>GitHubOAuthClient</code> will handle basic authentication as well.
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets a reference to the raw issues endpoint.
        /// </summary>
        public GitHubIssuesRawEndpoint Issues { get; private set; }

        /// <summary>
        /// Gets a reference to the raw organizations endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Organizations { get; private set; }

        /// <summary>
        /// Gets a reference to the raw repositories endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Repositories { get; private set; }

        /// <summary>
        /// Gets a reference to the raw user endpoint.
        /// </summary>
        public GitHubUserRawEndpoint User { get; private set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client with default options.
        /// </summary>
        public GitHubOAuthClient() {
            Issues = new GitHubIssuesRawEndpoint(this);
            Organizations = new GitHubOrganizationsRawEndpoint(this);
            Repositories = new GitHubRepositoriesRawEndpoint(this);
            User = new GitHubUserRawEndpoint(this);
            Users = new GitHubUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="accessToken"/>. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public GitHubOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/> and
        /// <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public GitHubOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/>, <paramref name="clientSecret"/>
        /// and <paramref name="redirectUri"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public GitHubOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an authorization URL using the specified <see cref="state"/>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <returns>Returns a <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, default(GitHubScopeCollection));
        }

        /// <summary>
        /// Gets an authorization URL using the specified <see cref="state"/> and request the specified
        /// <see cref="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>Returns a <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, GitHubScopeCollection scope) {
            return GetAuthorizationUrl(state, scope == null ? "" : scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <see cref="state"/>. and request the specified
        /// <see cref="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>Returns a <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException("state", "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Initialize the query string
            NameValueCollection nvc = new NameValueCollection {
                { "client_id", ClientId },
                {"redirect_uri", RedirectUri},
                {"state", state}
            };

            // Append the scope if specified
            string scopes = (scope == null ? "" : String.Join(",", scope));
            if (!String.IsNullOrWhiteSpace(scopes)) nvc.Add("scope", scopes);

            // Generate the URL
            return "https://github.com/login/oauth/authorize?" + SocialUtils.Misc.NameValueCollectionToQueryString(nvc);

        }

        /// <summary>
        /// Exchanges the specified <paramref name="authCode"/> for a user access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the GitHub OAuth dialog.</param>
        public GitHubAccessToken GetAccessTokenFromAuthCode(string authCode) {

            NameValueCollection parameters = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"code", authCode }
            };

            // Add the redirect URI (if specified)
            if (!String.IsNullOrWhiteSpace(RedirectUri)) parameters.Add("redirect_uri", RedirectUri);

            // Get the response from the server
            SocialHttpResponse response = SocialUtils.Http.DoHttpPostRequest("https://github.com/login/oauth/access_token", null, parameters);

            // Parse the contents
            NameValueCollection nvc = SocialUtils.Misc.ParseQueryString(response.Body);

            // Return the response
            return GitHubAccessToken.Parse(nvc);

        }

        internal string GenerateAbsoluteUrl(string relative) {
            return GenerateAbsoluteUrl(relative, null);
        }

        internal string GenerateAbsoluteUrl(string relative, NameValueCollection query) {

            if (query == null) query = new NameValueCollection();

            string url = "https://api.github.com";
            if (Credentials != null) {
                url = "https://" + Credentials.UserName + ":" + Credentials.Password + "@api.github.com";
            } else if (AccessToken != null) {
                query.Add("access_token", AccessToken);
            }

            // Add the relative URL
            url += relative;

            // Append the query string (if not empty)
            if (query.Count > 0) url += "?" + SocialUtils.Misc.NameValueCollectionToQueryString(query);

            // Now return the URL
            return url;

        }
        
        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The instance of <see cref="SocialHttpRequest"/> representing the request.</param>
        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            // GitHub requires a user agent - see https://developer.github.com/v3/#user-agent-required
            request.UserAgent = "Skybrud.Social";

            // Append the access token to the HTTP headers (if present)
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.Headers.Authorization = "token " + AccessToken;
            }

        }

        #endregion

    }

}