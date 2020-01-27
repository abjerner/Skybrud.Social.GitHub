using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.Issues.Comments;
using Skybrud.Social.GitHub.Endpoints.Issues.Events;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues;

namespace Skybrud.Social.GitHub.Endpoints.Issues {

    /// <summary>
    /// Class representing the raw <strong>Issues</strong> endpoint.
    /// </summary>
    public class GitHubIssuesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Issues/Comments</strong> endpoint.
        /// </summary>
        public GitHubIssuesCommentsRawEndpoint Comments { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Issues/Events</strong> endpoint.
        /// </summary>
        public GitHubIssuesEventsRawEndpoint Events { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
            Comments = new GitHubIssuesCommentsRawEndpoint(client);
            Events = new GitHubIssuesEventsRawEndpoint(client);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssue(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetIssue(new GitHubGetIssueOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssue(GitHubGetIssueOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues() {
            return Client.Get("/issues");
        }

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubGetIssuesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Get("/issues", options);
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias of the parent user or organization.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.Get($"/repos/{owner}/{repository}/issues");
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubGetRepositoryIssuesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.Owner)) throw new ArgumentNullException(nameof(options.Owner));
            if (string.IsNullOrWhiteSpace(options.Repository)) throw new PropertyNotSetException(nameof(options.Repository));
            return Client.Get($"/repos/{options.Owner}/{options.Repository}/issues", options);
        }

        #endregion

    }

}