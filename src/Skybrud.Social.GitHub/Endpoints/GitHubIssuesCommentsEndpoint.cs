using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Issues.Comments;
using Skybrud.Social.GitHub.Responses.Issues;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Issues/Comments</strong> endpoint.
    /// </summary>
    public class GitHubIssuesCommentsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubIssuesCommentsRawEndpoint Raw => Service.Client.Issues.Comments;

        #endregion

        #region Constructors

        internal GitHubIssuesCommentsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new comment to the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request.</param>
        /// <returns>An instance of <see cref="GitHubAddIssueCommentResponse"/> representing the response.</returns>
        public GitHubAddIssueCommentResponse AddComment(GitHubAddIssueCommentOptions options) {
            return GitHubAddIssueCommentResponse.ParseResponse(Raw.AddComment(options));
        }

        #endregion

    }

}