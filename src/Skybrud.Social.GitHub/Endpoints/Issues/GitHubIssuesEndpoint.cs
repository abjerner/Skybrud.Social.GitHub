using System;
using Skybrud.Social.GitHub.Endpoints.Issues.Comments;
using Skybrud.Social.GitHub.Endpoints.Issues.Events;
using Skybrud.Social.GitHub.Endpoints.Issues.Milestones;
using Skybrud.Social.GitHub.Models.Repositories;
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
        public GitHubHttpService Service { get; }

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

        internal GitHubIssuesEndpoint(GitHubHttpService service) {
            Service = service;
            Comments = new GitHubIssuesCommentsEndpoint(service);
            Events = new GitHubIssuesEventsEndpoint(service);
            Milestones = new GitHubMilestonesEndpoint(service);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-an-issue</cref>
        /// </see>
        public GitHubIssueResponse CreateIssue(GitHubCreateIssueOptions options) {
            return new GitHubIssueResponse(Raw.CreateIssue(options));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="GitHubIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public GitHubIssueResponse GetIssue(string owner, string repositoryAlias, int number) {
            return new GitHubIssueResponse(Raw.GetIssue(owner, repositoryAlias, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <returns>An instance of <see cref="GitHubIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public GitHubIssueResponse GetIssue(GitHubRepositoryBase repository, int number) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetIssue(new GitHubGetIssueOptions(repository, number));
        }

        /// <summary>
        /// Gets information about the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubIssueResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
        /// </see>
        public GitHubIssueResponse GetIssue(GitHubGetIssueOptions options) {
            return new GitHubIssueResponse(Raw.GetIssue(options));
        }

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
        public GitHubIssueListResponse GetIssues() {
            return new GitHubIssueListResponse(Raw.GetIssues());
        }

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
        public GitHubIssueListResponse GetIssues(GitHubGetIssuesOptions options) {
            return new GitHubIssueListResponse(Raw.GetIssues(options));
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
        public GitHubIssueListResponse GetIssues(string owner, string repositoryAlias) {
            return new GitHubIssueListResponse(Raw.GetIssues(owner, repositoryAlias));
        }

        /// <summary>
        /// Gets a list of issues for thespecified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
        public GitHubIssueListResponse GetIssues(GitHubRepositoryBase repository) {
            return new GitHubIssueListResponse(Raw.GetIssues(repository));
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
        public GitHubIssueListResponse GetIssues(GitHubGetRepositoryIssuesOptions options) {
            return new GitHubIssueListResponse(Raw.GetIssues(options));
        }

        #endregion

    }

}