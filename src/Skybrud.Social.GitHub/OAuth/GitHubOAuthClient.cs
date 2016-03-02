using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Objects.Authentication;
using Skybrud.Social.GitHub.Scopes;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.GitHub.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the GitHub API as well as any OAuth 2.0
    /// communication/authentication.
    /// </summary>
    public class GitHubOAuthClient {

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
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public GitHubOAuthClient() {
            Organizations = new GitHubOrganizationsRawEndpoint(this);
            Repositories = new GitHubRepositoriesRawEndpoint(this);
            User = new GitHubUserRawEndpoint(this);
            Users = new GitHubUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public GitHubOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public GitHubOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and redirect URI.
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
        /// Gets an authorization URL using the specified <code>state</code>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, default(GitHubScopeCollection));
        }

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, GitHubScopeCollection scope) {
            return GetAuthorizationUrl(state, scope == null ? "" : scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
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
            return "https://github.com/login/oauth/authorize?" + SocialUtils.NameValueCollectionToQueryString(nvc);

        }

        /// <summary>
        /// Exchanges the specified authorization code for a user access token.
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
            SocialHttpResponse response = SocialUtils.DoHttpPostRequest("https://github.com/login/oauth/access_token", null, parameters);

            // Parse the contents
            NameValueCollection nvc = SocialUtils.ParseQueryString(response.Body);

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
            if (query.Count > 0) url += "?" + SocialUtils.NameValueCollectionToQueryString(query);

            // Now return the URL
            return url;

        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, (SocialQueryString)null);
        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            return DoAuthenticatedGetRequest(url, new SocialQueryString(query));
        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IGetOptions options) {
            return DoAuthenticatedGetRequest(url, options == null ? null : options.GetQueryString());
        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Append the query string to the URL
            if (query != null && !query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // GitHub requires a user agent - see https://developer.github.com/v3/#user-agent-required
            request.UserAgent = "Skybrud.Social";

            // Add an authorization header with the access token
            request.Headers.Add("Authorization: token " + AccessToken);

            // Get the HTTP response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        #endregion

    }

}
