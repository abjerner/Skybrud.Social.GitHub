using System;
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

        private GitHubToken(IHttpQueryString query) {

            GitHubScopeCollection scopes = new GitHubScopeCollection();

            foreach (string scope in (query["scope"] ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
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

            AccessToken = query["access_token"];
            Scope = scopes;
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