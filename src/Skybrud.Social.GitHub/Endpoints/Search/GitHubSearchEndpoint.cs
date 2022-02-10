using Skybrud.Social.GitHub.Options.Search;
using Skybrud.Social.GitHub.Responses.Search;

namespace Skybrud.Social.GitHub.Endpoints.Search {

    /// <summary>
    /// Class representing the <strong>Search</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/search</cref>
    /// </see>
    public class GitHubSearchEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubSearchRawEndpoint Raw => Service.Client.Search;

        #endregion

        #region Constructors

        internal GitHubSearchEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the code results matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>An instance of <see cref="GitHubSearchCodeResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/search#search-code</cref>
        /// </see>
        public GitHubSearchCodeResponse SearchCode(string query) {
            return new GitHubSearchCodeResponse(Raw.SearchCode(query));
        }

        /// <summary>
        /// Returns the code results matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubSearchCodeResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/search#search-code</cref>
        /// </see>
        public GitHubSearchCodeResponse SearchCode(GitHubSearchCodeOptions options) {
            return new GitHubSearchCodeResponse(Raw.SearchCode(options));
        }

        #endregion

    }

}