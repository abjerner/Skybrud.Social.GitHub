using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints {
    
    /// <summary>
    /// Class representing the organizations endpoint.
    /// </summary>
    public class GitHubOrganizationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Raw {
            get { return Service.Client.Organizations; }
        }

        #endregion

        #region Constructors

        internal GitHubOrganizationsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <see cref="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>Returns an instance of <see cref="GitHubGetOrganizationResponse"/> representing the response.</returns>
        public GitHubGetOrganizationResponse GetOrganization(string alias) {
            return GitHubGetOrganizationResponse.ParseResponse(Raw.GetOrganization(alias));
        }

        #endregion
    
    }

}