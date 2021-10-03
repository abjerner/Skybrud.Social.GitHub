using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;
using Skybrud.Social.GitHub.Options.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Teams;
using System;

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

        /// <summary>
        /// Gets a reference to the <strong>Organizations/Members</strong> endpoint.
        /// </summary>
        public GitHubOrganizationMembersEndpoint Members { get; }

        /// <summary>
        /// Gets a reference to the <strong>Organizations/OutsideCollaborators</strong> endpoint.
        /// </summary>
        public GitHubOrganizationOutsideCollaboratorsEndpoint OutsideCollaborators { get; }

        #endregion

        #region Constructors

        internal GitHubOrganizationsEndpoint(GitHubHttpService service) {
            Service = service;
            Members = new GitHubOrganizationMembersEndpoint(service);
            OutsideCollaborators = new GitHubOrganizationOutsideCollaboratorsEndpoint(service);
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

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations() {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations());
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(options));
        }

        /// <summary>
        /// Gets a list of public organizations of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(string username) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(username));
        }

        /// <summary>
        /// Gets a list of public organizations of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubGetUserOrganizationsOptions options) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(options));
        }

        /// <summary>
        /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return new GitHubRepositoryListResponse(Raw.GetRepositories(options));
        }

        #endregion

    }

}