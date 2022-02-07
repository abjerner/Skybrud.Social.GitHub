using Skybrud.Social.GitHub.Endpoints.PullRequests.Reviews;
using Skybrud.Social.GitHub.Options.PullRequests;
using Skybrud.Social.GitHub.Responses;
using Skybrud.Social.GitHub.Responses.PullRequests;

namespace Skybrud.Social.GitHub.Endpoints.PullRequests {

    /// <summary>
    /// Class representing the <strong>Pull Requests</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/pulls/</cref>
    /// </see>
    public class GitHubPullRequestsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubPullRequestsRawEndpoint Raw => Service.Client.PullRequests;

        /// <summary>
        /// Gets a reference to the <strong>Pull Requests/Reviews</strong> endpoint.
        /// </summary>
        public GitHubPullReviewsEndpoint Reviews { get; }

        #endregion

        #region Constructors

        internal GitHubPullRequestsEndpoint(GitHubHttpService service) {
            Service = service;
            Reviews = new GitHubPullReviewsEndpoint(service);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new pull request with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/pulls#create-a-pull-request</cref>
        /// </see>
        public GitHubPullRequestResponse CreatePullRequest(GitHubCreatePullRequestOptions options) {
            return new GitHubPullRequestResponse(Raw.CreatePullRequest(options));
        }

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <param name="number">The number of the pull request.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestResponse"/> representing the response.</returns>
        public GitHubPullRequestResponse GetPullRequest(string owner, string repository, int number) {
            return new GitHubPullRequestResponse(Raw.GetPullRequest(owner, repository, number));
        }

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestResponse"/> representing the response.</returns>
        public GitHubPullRequestResponse GetPullRequest(GitHubGetPullRequestOptions options) {
            return new GitHubPullRequestResponse(Raw.GetPullRequest(options));
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository 
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestListResponse"/> representing the response.</returns>
        public GitHubPullRequestListResponse GetPullRequests(string owner, string repository) {
            return new GitHubPullRequestListResponse(Raw.GetPullRequests(owner, repository));
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestListResponse"/> representing the response.</returns>
        public GitHubPullRequestListResponse GetPullRequests(GitHubGetPullRequestsOptions options) {
            return new GitHubPullRequestListResponse(Raw.GetPullRequests(options));
        }

        #endregion

    }

}