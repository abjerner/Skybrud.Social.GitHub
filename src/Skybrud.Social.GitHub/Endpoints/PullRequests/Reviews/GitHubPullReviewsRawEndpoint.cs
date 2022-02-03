using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.PullRequests.Reviews;

namespace Skybrud.Social.GitHub.Endpoints.PullRequests.Reviews {

    /// <summary>
    /// Class representing the raw <strong>Pull Requests/Reviews</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/pulls/reviews/</cref>
    /// </see>
    public class GitHubPullReviewsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubPullReviewsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of reviews of the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReviews(string owner, string repository, int number) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetReviews(new GitHubGetReviewsOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of reviews matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReviews(GitHubGetReviewsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}