using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.PullRequests;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw <strong>Pull requests</strong> endpoint.
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

        #endregion

        #region Constructors

        internal GitHubPullRequestsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
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
            if (String.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (String.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.DoHttpGetRequest($"/repos/{owner}/{repository}/pulls/" + number);
        }
        
        /// <summary>
        /// Gets a list of pull requests matching the repository 
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequests(string owner, string repository) {
            if (String.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (String.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.DoHttpGetRequest($"/repos/{owner}/{repository}/pulls");
        }

        /// <summary>
        /// Gets a list of pull requests matching the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPullRequests(GitHubGetPullRequestsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (String.IsNullOrWhiteSpace(options.Owner)) throw new ArgumentNullException(nameof(options.Owner));
            if (String.IsNullOrWhiteSpace(options.Repository)) throw new ArgumentNullException(nameof(options.Repository));
            return Client.DoHttpGetRequest($"/repos/{options.Owner}/{options.Repository}/pulls", options);
        }

        #endregion

    }

}