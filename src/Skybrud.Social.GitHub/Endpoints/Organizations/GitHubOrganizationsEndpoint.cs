using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

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

        internal GitHubOrganizationsEndpoint(GitHubService service) {
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
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int id) {
            return new GitHubTeamListResponse(Raw.GetTeams(id));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int id, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(id, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int id, int page, int perPage) {
            return new GitHubTeamListResponse(Raw.GetTeams(id, page, perPage));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string alias) {
            return new GitHubTeamListResponse(Raw.GetTeams(alias));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string alias, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(alias, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string alias, int page, int perPage) {
            return new GitHubTeamListResponse(Raw.GetTeams(alias, page, perPage));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="org"/>.
        /// </summary>
        /// <param name="org">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(string org, string name) {
            return new GitHubTeamResponse(Raw.CreateTeam(org, name));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="org"/>.
        /// </summary>
        /// <param name="org">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <param name="description">The description of the team to be created.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(string org, string name, string description) {
            return new GitHubTeamResponse(Raw.CreateTeam(org, name, description));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(GitHubCreateTeamOptions options) {
            return new GitHubTeamResponse(Raw.CreateTeam(options));
        }

        #endregion

    }

}