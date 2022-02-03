using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    /// <summary>
    /// Class representing the raw <strong>Organizations</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/orgs/</cref>
    /// </see>
    public partial class GitHubOrganizationsRawEndpoint {

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
        /// Gets information about the organisation with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganization(int organizationId) {
            return Client.Get($"/organizations/{organizationId}");
        }

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganization(string organizationAlias) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return Client.Get($"/orgs/{organizationAlias}");
        }

        #endregion

    }

}