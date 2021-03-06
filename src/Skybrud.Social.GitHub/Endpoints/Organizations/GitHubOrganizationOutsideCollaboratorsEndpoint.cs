using Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {
    
    /// <summary>
    /// Class representing the <strong>Organizations/OutsideCollaborators</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#outside-collaborators</cref>
    /// </see>
    public class GitHubOrganizationOutsideCollaboratorsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationOutsideCollaboratorsRawEndpoint Raw => Service.Client.Organizations.OutsideCollaborators;

        #endregion

        #region Constructors

        internal GitHubOrganizationOutsideCollaboratorsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region member methods

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(string organization) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(organization));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(GitHubGetOutsideCollaboratorsOptions options) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(options));
        }

        #endregion
    
    }

}