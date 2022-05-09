using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.GraphQl {

    /// <summary>
    /// Class representing the raw <strong>GraphQL</strong> endpoint.
    /// </summary>
    public class GraphQlRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GraphQlRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetResponse(string query) {

            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));

            JObject body = new() {
                { "query", query }
            };

            return Client.Post("/graphql", body);

        }

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public async Task<IHttpResponse> GetResponseAsync(string query) {

            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));

            JObject body = new() {
                { "query", query }
            };

            return await Client.PostAsync("/graphql", body);

        }

        #endregion

    }

}