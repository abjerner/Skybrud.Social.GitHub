using Skybrud.Social.GitHub.Endpoints.Issues.Comments;
using Skybrud.Social.GitHub.Endpoints.Issues.Events;
using Skybrud.Social.GitHub.Endpoints.Issues.Milestones;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.GitHub.Responses.Issues;

namespace Skybrud.Social.GitHub.Endpoints.Issues {

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

        /// <summary>
        /// Gets a reference to the <strong>Issues/Milestones</strong> endpoint.
        /// </summary>
        public GitHubMilestonesEndpoint Milestones { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesEndpoint(GitHubService service) {
            Service = service;
            Comments = new GitHubIssuesCommentsEndpoint(service);
            Events = new GitHubIssuesEventsEndpoint(service);
            Milestones = new GitHubMilestonesEndpoint(service);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="GitHubGetIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public GitHubGetIssueResponse GetIssue(string owner, string repository, int number) {
            return GitHubGetIssueResponse.Parse(Raw.GetIssue(owner, repository, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public GitHubGetIssueResponse GetIssue(GitHubGetIssueOptions options) {
            return GitHubGetIssueResponse.Parse(Raw.GetIssue(options));
        }
        
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