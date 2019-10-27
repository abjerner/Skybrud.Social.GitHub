using System;
using Skybrud.Social.GitHub.Models.PullRequests;
using Skybrud.Social.GitHub.Options.PullRequests.Reviews;
using Skybrud.Social.GitHub.Responses.PullRequests.Reviews;

namespace Skybrud.Social.GitHub.Endpoints.PullRequests.Reviews {

    /// <summary>
    /// Class representing the <strong>Pull Requests/Reviews</strong> endpoint.
    /// </summary>
    public class GitHubPullReviewsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubPullReviewsRawEndpoint Raw => Service.Client.PullRequests.Reviews;

        #endregion

        #region Constructors

        internal GitHubPullReviewsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of reviews of the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="GitHubReviewListResponse"/> representing the response.</returns>
        public GitHubReviewListResponse GetReviews(string owner, string repository, int number) {
            return GetReviews(new GitHubGetReviewsOptions(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of reviews of the specified <paramref name="pullRequest"/>.
        /// </summary>
        /// <param name="pullRequest">The pull request to get reviews for.</param>
        /// <returns>An instance of <see cref="GitHubReviewListResponse"/> representing the response.</returns>
        public GitHubReviewListResponse GetReviews(GitHubPullRequestBase pullRequest) {
            if (pullRequest == null) throw new ArgumentNullException(nameof(pullRequest));
            return GitHubReviewListResponse.Parse(Raw.GetReviews(new GitHubGetReviewsOptions(pullRequest)));
        }

        /// <summary>
        /// Gets a list of reviews matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubReviewListResponse"/> representing the response.</returns>
        public GitHubReviewListResponse GetReviews(GitHubGetReviewsOptions options) {
            return GitHubReviewListResponse.Parse(Raw.GetReviews(options));
        }

        #endregion

    }

}