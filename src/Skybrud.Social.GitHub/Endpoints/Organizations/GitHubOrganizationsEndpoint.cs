using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    /// <summary>
    /// Class representing the <strong>Organizations</strong> endpoint.
    /// </summary>
    public partial class GitHubOrganizationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Raw => Service.Client.Organizations;

        #endregion

        #region Constructors

        internal GitHubOrganizationsEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationResponse"/> representing the response.</returns>
        public GitHubOrganizationResponse GetOrganization(int id) {
            return new GitHubOrganizationResponse(Raw.GetOrganization(id));
        }

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationResponse"/> representing the response.</returns>
        public GitHubOrganizationResponse GetOrganization(string alias) {
            return new GitHubOrganizationResponse(Raw.GetOrganization(alias));
        }

        #endregion

    }

}