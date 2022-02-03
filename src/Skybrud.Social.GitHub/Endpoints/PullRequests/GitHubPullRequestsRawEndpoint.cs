using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.PullRequests.Reviews;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.PullRequests;

namespace Skybrud.Social.GitHub.Endpoints.PullRequests {

    /// <summary>
    /// Class representing the raw <strong>Pull Requests</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/pulls/</cref>
    /// </see>
    public class GitHubPullRequestsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Pull Requests/Reviews</strong> endpoint.
        /// </summary>
        public GitHubPullReviewsRawEndpoint Reviews { get; }

        #endregion

        #region Constructors

        internal GitHubPullRequestsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
            Reviews = new GitHubPullReviewsRawEndpoint(client);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <param name="number">The number of the pull request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequest(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetPullRequest(new GitHubGetPullRequestOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequest(GitHubGetPullRequestOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository 
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequests(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetPullRequests(new GitHubGetPullRequestsOptions(owner, repository));
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequests(GitHubGetPullRequestsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}