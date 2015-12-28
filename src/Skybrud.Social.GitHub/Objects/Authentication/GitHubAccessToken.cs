using System;
using System.Collections.Specialized;
using Skybrud.Social.GitHub.Scopes;

namespace Skybrud.Social.GitHub.Objects.Authentication {

    /// <summary>
    /// Class representing the response body of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubAccessToken {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets a collection representing the granted scope.
        /// </summary>
        public GitHubScopeCollection Scope { get; private set; }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        public string TokenType { get; private set; }

        #endregion

        #region Constructors

        private GitHubAccessToken(NameValueCollection nvc) {

            GitHubScopeCollection scopes = new GitHubScopeCollection();

            foreach (string scope in (nvc["scope"] ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                switch (scope) {
                    case "user": scopes.Add(GitHubScopes.User); break;
                    case "user:email": scopes.Add(GitHubScopes.UserEmail); break;
                    case "user:follow": scopes.Add(GitHubScopes.UserFollow); break;
                    case "public_repo": scopes.Add(GitHubScopes.PublicRepo); break;
                    case "repo": scopes.Add(GitHubScopes.Repo); break;
                    case "repo:status": scopes.Add(GitHubScopes.RepoStatus); break;
                    case "delete_repo": scopes.Add(GitHubScopes.DeleteRepo); break;
                    case "notifications": scopes.Add(GitHubScopes.Notifications); break;
                    case "gist": scopes.Add(GitHubScopes.Gist); break;
                    default: scopes.Add(new GitHubScope(scope)); break;
                }
            }

            AccessToken = nvc["access_token"];
            Scope = scopes;
            TokenType = nvc["token_type"];

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>nvc</code> into an instance of <code>GitHubAccessToken</code>.
        /// </summary>
        /// <param name="nvc">The instance of <code>NameValueCollection</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubAccessToken</code>.</returns>
        public static GitHubAccessToken Parse(NameValueCollection nvc) {
            return nvc == null ? null : new GitHubAccessToken(nvc);
        }

        #endregion

    }

}