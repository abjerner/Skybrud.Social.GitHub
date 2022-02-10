using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Search {
    
    /// <summary>
    /// Class with options for doing a code based search of GitHub.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/search#search-code</cref>
    /// </see>
    public class GitHubSearchCodeOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Query { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubSearchCodeOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        public GitHubSearchCodeOptions(string query) {
            Query = query;
        }

        #endregion
        
        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(Query)) throw new PropertyNotSetException(nameof(Query));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString {{"q", Query}};

            // Initialize a new PUT request
            return HttpRequest
                .Get("/search/code", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}