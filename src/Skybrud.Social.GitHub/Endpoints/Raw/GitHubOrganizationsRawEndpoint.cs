using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw organizations endpoint.
    /// </summary>
    public class GitHubOrganizationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubOrganizationsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <code>alias</code>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetOrganization(string alias) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/orgs/" + alias);
        }

        #endregion

    }

}