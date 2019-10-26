using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.PullRequests;
using Skybrud.Social.GitHub.Responses.PullRequests;

namespace Skybrud.Social.GitHub.Endpoints {

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
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubPullRequestsRawEndpoint Raw => Service.Client.PullRequests;

        #endregion

        #region Constructors

        internal GitHubPullRequestsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <param name="number">The number of the pull request.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestResponse"/> representing the response.</returns>
        public GitHubGetPullRequestResponse GetPullRequest(string owner, string repository, int number) {
            return GitHubGetPullRequestResponse.ParseResponse(Raw.GetPullRequest(owner, repository, number));
        }

        /// <summary>
        /// Gets the pull request matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <param name="number">The number of the pull request.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestResponse"/> representing the response.</returns>
        public GitHubGetPullRequestResponse GetPullRequests(string owner, string repository, int number) {
            return GitHubGetPullRequestResponse.ParseResponse(Raw.GetPullRequest(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository 
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestsResponse"/> representing the response.</returns>
        public GitHubGetPullRequestsResponse GetPullRequests(string owner, string repository) {
            return GitHubGetPullRequestsResponse.ParseResponse(Raw.GetPullRequests(owner, repository));
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestsResponse"/> representing the response.</returns>
        public GitHubGetPullRequestsResponse GetPullRequests(GitHubGetPullRequestsOptions options) {
            return GitHubGetPullRequestsResponse.ParseResponse(Raw.GetPullRequests(options));
        }

        #endregion
    
    }

}