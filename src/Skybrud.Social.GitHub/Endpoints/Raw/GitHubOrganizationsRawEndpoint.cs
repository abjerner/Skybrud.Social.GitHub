using System;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Organizations</strong> endpoint.
    /// </summary>
    public class GitHubOrganizationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubOrganizationsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetOrganization(string alias) {
            if (String.IsNullOrWhiteSpace(alias)) throw new ArgumentNullException(nameof(alias));
            return Client.DoHttpGetRequest("/orgs/" + alias);
        }

        #endregion

    }

}