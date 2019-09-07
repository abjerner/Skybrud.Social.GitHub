using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues.Comments;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw <strong>Issues/Comments</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/comments/</cref>
    /// </see>
    public class GitHubIssuesCommentsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesCommentsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new comment with the specified <paramref name="body"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <param name="body">The Markdown-based body of the comment.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse AddComment(string owner, string repository, int number, string body) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentNullException(nameof(body));
            return AddComment(new GitHubAddIssueCommentOptions(owner, repository, number, body));
        }

        /// <summary>
        /// Adds a new comment with the specified <paramref name="body"/>.
        /// </summary>
        /// <param name="issue">The issue to which the comment will be added.</param>
        /// <param name="body">The Markdown-based body of the comment.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse AddComment(GitHubIssue issue, string body) {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentNullException(nameof(body));
            return AddComment(new GitHubAddIssueCommentOptions(issue, body));
        }

        /// <summary>
        /// Adds a new comment to the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse AddComment(GitHubAddIssueCommentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of comments of the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/comments/#list-comments-on-an-issue</cref>
        /// </see>
        public IHttpResponse GetComments(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetComments(new GitHubGetIssueCommentsOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of comments of the specified <paramref name="issue"/>.
        /// </summary>
        /// <param name="issue">The issue to get comments for.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/comments/#list-comments-on-an-issue</cref>
        /// </see>
        public IHttpResponse GetComments(GitHubIssue issue) {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            return GetComments(new GitHubGetIssueCommentsOptions(issue));
        }

        /// <summary>
        /// Gets a list of comments of the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/comments/#list-comments-on-an-issue</cref>
        /// </see>
        public IHttpResponse GetComments(GitHubGetIssueCommentsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}