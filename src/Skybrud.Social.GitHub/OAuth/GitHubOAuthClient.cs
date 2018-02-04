using System;
using System.Net;
using Skybrud.Essentials.Common;
using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Authentication;
using Skybrud.Social.GitHub.Scopes;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

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
        /// The GitHub API supports basic authentication, so even though this is not a part of OAuth, the
        /// <see cref="GitHubOAuthClient"/> class will handle basic authentication as well.
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets a reference to the raw issues endpoint.
        /// </summary>
        public GitHubIssuesRawEndpoint Issues { get; }

        /// <summary>
        /// Gets a reference to the raw organizations endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Organizations { get; }

        /// <summary>
        /// Gets a reference to the raw repositories endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Repositories { get; }

        /// <summary>
        /// Gets a reference to the raw user endpoint.
        /// </summary>
        public GitHubUserRawEndpoint User { get; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Users { get; }

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

        /// <summary>
        /// Initializes a new OAuth client based on the specified <paramref name="credentials"/>.
        /// </summary>
        /// <param name="credentials">An instance of <paramref name="credentials"/> representing the username and password of the user.</param>
        public GitHubOAuthClient(NetworkCredential credentials) : this() {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/>. This URL will only make your
        /// application request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <returns>A <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, default(GitHubScopeCollection));
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/> and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>A <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, GitHubScope scope) {
            return GetAuthorizationUrl(state, scope == null ? null : new GitHubScopeCollection(scope));
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/> and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>A <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, params GitHubScope[] scope) {
            return GetAuthorizationUrl(state, scope == null ? null : new GitHubScopeCollection(scope));
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/> and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>A <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, GitHubScopeCollection scope) {
            return GetAuthorizationUrl(state, scope == null ? "" : scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <paramref name="state"/>. and request the specified
        /// <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>A <see cref="String"/> with the authorization URL.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Some input validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException(nameof(state), "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Initialize the query string
            IHttpQueryString query = new SocialHttpQueryString {
                {"client_id", ClientId },
                {"redirect_uri", RedirectUri},
                {"state", state}
            };

            // Append the scope if specified
            string scopes = scope == null ? "" : String.Join(",", scope);
            if (!String.IsNullOrWhiteSpace(scopes)) query.Add("scope", scopes);

            // Generate the URL
            return "https://github.com/login/oauth/authorize?" + query;

        }

        /// <summary>
        /// Exchanges the specified <paramref name="authorizationCode"/> for a user access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the GitHub OAuth dialog.</param>
        public GitHubTokenResponse GetAccessTokenFromAuthorizationCode(string authorizationCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(authorizationCode)) throw new ArgumentNullException(nameof(authorizationCode));

            IHttpPostData parameters = new SocialHttpPostData {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"code", authorizationCode }
            };

            // Add the redirect URI (if specified)
            if (!String.IsNullOrWhiteSpace(RedirectUri)) parameters.Add("redirect_uri", RedirectUri);

            // Get the response from the server
            SocialHttpResponse response = SocialUtils.Http.DoHttpPostRequest("https://github.com/login/oauth/access_token", null, parameters);
            
            // Return the response
            return GitHubTokenResponse.ParseResponse(response);

        }
        
        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The instance of <see cref="SocialHttpRequest"/> representing the request.</param>
        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            // Append scheme and host if not already present
            if (request.Url.StartsWith("/")) request.Url = "https://api.github.com" + request.Url;

            // GitHub requires a user agent - see https://developer.github.com/v3/#user-agent-required
            request.UserAgent = "Skybrud.Social";
            
            // Append the access token to the HTTP headers (if present)
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.Headers.Authorization = "token " + AccessToken;
            }

            // Set the credentials for basic authentication (if present)
            if (Credentials != null) {
                request.Credentials = Credentials;
            }

        }

        #endregion

    }

}