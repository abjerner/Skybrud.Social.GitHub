using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Search;

namespace Skybrud.Social.GitHub.Endpoints.Search {

    /// <summary>
    /// Class representing the raw <strong>Search</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/search</cref>
    /// </see>
    public class GitHubSearchRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubSearchRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the code results matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/search#search-code</cref>
        /// </see>
        public IHttpResponse SearchCode(string query) {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));
            return SearchCode(new GitHubSearchCodeOptions(query));
        }

        /// <summary>
        /// Returns the code results matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/search#search-code</cref>
        /// </see>
        public IHttpResponse SearchCode(GitHubSearchCodeOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}