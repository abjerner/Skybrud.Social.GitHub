using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.GitHub.Responses.Issues;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Issues</strong> endpoint.
    /// </summary>
    public class GitHubIssuesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubIssuesRawEndpoint Raw => Service.Client.Issues;

        #endregion

        #region Constructors

        internal GitHubIssuesEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetIssuesResponse"/> representing the response.</returns>
        public GitHubGetIssuesResponse GetIssues() {
            return GitHubGetIssuesResponse.ParseResponse(Raw.GetIssues());
        }

        /// <summary>
        /// Gets a list of issues matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetIssuesResponse"/> representing the response.</returns>
        public GitHubGetIssuesResponse GetIssues(GitHubGetIssuesOptions options) {
            return GitHubGetIssuesResponse.ParseResponse(Raw.GetIssues(options));
        }

        #endregion

    }

}