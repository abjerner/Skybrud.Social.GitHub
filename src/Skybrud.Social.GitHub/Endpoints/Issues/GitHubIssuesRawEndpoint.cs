using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.Issues.Comments;
using Skybrud.Social.GitHub.Endpoints.Issues.Events;
using Skybrud.Social.GitHub.Endpoints.Issues.Milestones;
using Skybrud.Social.GitHub.Models.Repositories;
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

        /// <summary>
        /// Gets a reference to the raw <strong>Issues/Milestones</strong> endpoint.
        /// </summary>
        public GitHubMilestonesRawEndpoint Milestones { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
            Comments = new GitHubIssuesCommentsRawEndpoint(client);
            Events = new GitHubIssuesEventsRawEndpoint(client);
            Milestones = new GitHubMilestonesRawEndpoint(client);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-an-issue</cref>
        /// </see>
        public IHttpResponse CreateIssue(GitHubCreateIssueOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public IHttpResponse GetIssue(string owner, string repositoryAlias, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetIssue(new GitHubGetIssueOptions(owner, repositoryAlias, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public IHttpResponse GetIssue(GitHubRepositoryBase repository, int number) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetIssue(new GitHubGetIssueOptions(repository, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
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
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(string owner, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetIssues(new GitHubGetRepositoryIssuesOptions(owner, repositoryAlias));
        }

        /// <summary>
        /// Gets a list of issues for the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetIssues(new GitHubGetRepositoryIssuesOptions(repository));
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubGetRepositoryIssuesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}