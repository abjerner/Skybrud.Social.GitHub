using System;
using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.PullRequests;
using Skybrud.Social.GitHub.Options.Issues.Comments;
using Skybrud.Social.GitHub.Responses.Issues.Comments;

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
        /// <returns>An instance of <see cref="GitHubCommentResponse"/> representing the response.</returns>
        public GitHubCommentResponse AddComment(GitHubAddIssueCommentOptions options) {
            return GitHubCommentResponse.Parse(Raw.AddComment(options));
        }

        /// <summary>
        /// Gets a list of comments of the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="GitHubCommentListResponse"/> representing the response.</returns>
        public GitHubCommentListResponse GetComments(string owner, string repository, int number) {
            return GitHubCommentListResponse.Parse(Raw.GetComments(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of comments of the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubCommentListResponse"/> representing the response.</returns>
        public GitHubCommentListResponse GetComments(GitHubGetIssueCommentsOptions options) {
            return GitHubCommentListResponse.Parse(Raw.GetComments(options));
        }

        /// <summary>
        /// Gets a list of comments of the specified <paramref name="issue"/>.
        /// </summary>
        /// <param name="issue">The issue to get comments for.</param>
        /// <returns>An instance of <see cref="GitHubCommentListResponse"/> representing the response.</returns>
        public GitHubCommentListResponse GetComments(GitHubIssueBase issue) {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            return GitHubCommentListResponse.Parse(Raw.GetComments(new GitHubGetIssueCommentsOptions(issue)));
        }

        /// <summary>
        /// Gets a list of comments of the specified <paramref name="pullRequest"/>.
        /// </summary>
        /// <param name="pullRequest">The pull request to get comments for.</param>
        /// <returns>An instance of <see cref="GitHubCommentListResponse"/> representing the response.</returns>
        public GitHubCommentListResponse GetComments(GitHubPullRequestBase pullRequest) {
            if (pullRequest == null) throw new ArgumentNullException(nameof(pullRequest));
            return GitHubCommentListResponse.Parse(Raw.GetComments(new GitHubGetIssueCommentsOptions(pullRequest)));
        }

        #endregion

    }

}