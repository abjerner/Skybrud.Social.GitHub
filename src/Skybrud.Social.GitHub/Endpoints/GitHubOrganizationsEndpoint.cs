using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Organizations</strong> endpoint.
    /// </summary>
    public class GitHubOrganizationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Raw => Service.Client.Organizations;

        #endregion

        #region Constructors

        internal GitHubOrganizationsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationResponse"/> representing the response.</returns>
        public GitHubGetOrganizationResponse GetOrganization(string alias) {
            return GitHubGetOrganizationResponse.ParseResponse(Raw.GetOrganization(alias));
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public GitHubGetOrganizationsResponse GetOrganizations() {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations());
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public GitHubGetOrganizationsResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations(options));
        }

        /// <summary>
        /// Gets a list of public organizations of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public GitHubGetOrganizationsResponse GetOrganizations(string username) {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations(username));
        }

        /// <summary>
        /// Gets a list of public organizations of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public GitHubGetOrganizationsResponse GetOrganizations(GitHubGetUserOrganizationsOptions options) {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations(options));
        }

        #endregion
    
    }

}