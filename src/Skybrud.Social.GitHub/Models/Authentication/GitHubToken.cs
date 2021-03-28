using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Scopes;

namespace Skybrud.Social.GitHub.Models.Authentication {

    /// <summary>
    /// Class representing the response body of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubToken {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets a list representing the granted scope.
        /// </summary>
        public GitHubScopeList Scope { get; }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        public string TokenType { get; }

        #endregion

        #region Constructors

        private GitHubToken(IHttpQueryString query) {
            AccessToken = query["access_token"];
            Scope = GitHubScopeList.Parse(query["scope"]);
            TokenType = query["token_type"];
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="query"/> into an instance of <see cref="GitHubToken"/>.
        /// </summary>
        /// <param name="query">The instance of <see cref="IHttpQueryString"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubToken"/>.</returns>
        public static GitHubToken Parse(IHttpQueryString query) {
            return query == null ? null : new GitHubToken(query);
        }

        #endregion

    }

}