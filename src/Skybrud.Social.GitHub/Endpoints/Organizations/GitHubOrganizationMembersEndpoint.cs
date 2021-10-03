using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    /// <summary>
    /// Class representing the <strong>Organizations/Members</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#members</cref>
    /// </see>
    public class GitHubOrganizationMembersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationMembersRawEndpoint Raw => Service.Client.Organizations.Members;

        #endregion

        #region Constructors

        internal GitHubOrganizationMembersEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region member methods

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(string organization) {
            return new GitHubUserListResponse(Raw.GetMembers(organization));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(GitHubGetOrganizationMembersOptions options) {
            return new GitHubUserListResponse(Raw.GetMembers(options));
        }

        #endregion
    
    }

}