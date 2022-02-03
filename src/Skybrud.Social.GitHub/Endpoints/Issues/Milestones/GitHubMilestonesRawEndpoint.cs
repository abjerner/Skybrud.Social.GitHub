using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues.Milestones;

namespace Skybrud.Social.GitHub.Endpoints.Issues.Milestones {

    /// <summary>
    /// Class representing the raw <strong>Issues/Milestones</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/</cref>
    /// </see>
    public class GitHubMilestonesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubMilestonesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new milestone with <paramref name="title"/> in the repository matching the specified
        /// <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="title">The title of the milestone.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#create-a-milestone</cref>
        /// </see>
        public IHttpResponse CreateMilestone(string owner, string repository, string title) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));
            return CreateMilestone(new GitHubCreateMilestoneOptions(owner, repository, title));
        }

        /// <summary>
        /// Creates a new milestone in the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#create-a-milestone</cref>
        /// </see>
        public IHttpResponse CreateMilestone(GitHubCreateMilestoneOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the milestone matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the milestone.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#get-a-single-milestone</cref>
        /// </see>
        public IHttpResponse GetMilestone(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.GetResponse(new GitHubGetMilestoneOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets the milestone matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#get-a-single-milestone</cref>
        /// </see>
        public IHttpResponse GetMilestone(GitHubGetMilestoneOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Updates the milestone with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#update-a-milestone</cref>
        /// </see>
        public IHttpResponse UpdateMilestone(GitHubUpdateMilestoneOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Deletes the milestone matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the milestone.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public IHttpResponse DeleteMilestone(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.GetResponse(new GitHubDeleteMilestoneOptions(owner, repository, number));
        }

        /// <summary>
        /// Deletes the specified <paramref name="milestone"/>.
        /// </summary>
        /// <param name="milestone">The milestone to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public IHttpResponse DeleteMilestone(GitHubMilestone milestone) {
            if (milestone == null) throw new ArgumentNullException(nameof(milestone));
            return Client.GetResponse(new GitHubDeleteMilestoneOptions(milestone));
        }

        /// <summary>
        /// Deletes the milestone matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public IHttpResponse DeleteMilestone(GitHubDeleteMilestoneOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the milestones of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#list-milestones-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetMilestones(GitHubGetMilestonesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}