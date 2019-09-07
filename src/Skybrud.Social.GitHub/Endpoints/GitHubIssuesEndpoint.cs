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

        /// <summary>
        /// Gets a reference to the <strong>Issues/Comments</strong> endpoint.
        /// </summary>
        public GitHubIssuesCommentsEndpoint Comments { get; }

        /// <summary>
        /// Gets a reference to the <strong>Issues/Events</strong> endpoint.
        /// </summary>
        public GitHubIssuesEventsEndpoint Events { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesEndpoint(GitHubService service) {
            Service = service;
            Comments = new GitHubIssuesCommentsEndpoint(service);
            Events = new GitHubIssuesEventsEndpoint(service);
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
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetIssuesResponse"/> representing the response.</returns>
        public GitHubGetIssuesResponse GetIssues(GitHubGetIssuesOptions options) {
            return GitHubGetIssuesResponse.ParseResponse(Raw.GetIssues(options));
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias of the parent user or organization.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubGetIssuesResponse"/> representing the response.</returns>
        public GitHubGetIssuesResponse GetIssues(string owner, string repository) {
            return GitHubGetIssuesResponse.ParseResponse(Raw.GetIssues(owner, repository));
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetIssuesResponse"/> representing the response.</returns>
        public GitHubGetIssuesResponse GetIssues(GitHubGetRepositoryIssuesOptions options) {
            return GitHubGetIssuesResponse.ParseResponse(Raw.GetIssues(options));
        }

        #endregion

    }

}