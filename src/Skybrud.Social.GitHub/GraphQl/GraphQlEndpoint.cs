using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.GraphQl.Responses;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.GraphQl {

    /// <summary>
    /// Class representing the <strong>GraphQL</strong> endpoint.
    /// </summary>
    public class GraphQlEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GraphQlRawEndpoint Raw => Service.Client.GraphQl;

        #endregion

        #region Constructors

        internal GraphQlEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public GitHubResponse GetResponse(string query) {
            return new(Raw.GetResponse(query));
        }

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public async Task<GitHubResponse> GetResponseAsync(string query) {
            return new(await Raw.GetResponseAsync(query));
        }

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public OrganizationResponse GetOrganization(string query) {
            return new(Raw.GetResponse(query));
        }

        /// <summary>
        /// Returns a response based on the specified GraphQL <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The GraphQL query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public async Task<OrganizationResponse> GetOrganizationAsync(string query) {
            return new(await Raw.GetResponseAsync(query));
        }

        #endregion

    }

}