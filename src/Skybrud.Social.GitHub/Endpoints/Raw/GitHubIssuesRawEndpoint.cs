using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw issues endpoint.
    /// </summary>
    public class GitHubIssuesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubIssuesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetIssues() {
            return Client.DoHttpGetRequest("https://api.github.com/issues");
        }

        /// <summary>
        /// Gets a list of issues matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetIssues(GitHubGetIssuesOptions options) {
            return Client.DoHttpGetRequest("https://api.github.com/issues", options);
        }

        #endregion

    }

}