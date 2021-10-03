using Skybrud.Social.GitHub.Options.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="organisationAlias"/>.
        /// </summary>
        /// <param name="organisationAlias">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(string organisationAlias, string name) {
            return new GitHubTeamResponse(Raw.CreateTeam(organisationAlias, name));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="organisationAlias"/>.
        /// </summary>
        /// <param name="organisationAlias">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <param name="description">The description of the team to be created.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(string organisationAlias, string name, string description) {
            return new GitHubTeamResponse(Raw.CreateTeam(organisationAlias, name, description));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse CreateTeam(GitHubCreateTeamOptions options) {
            return new GitHubTeamResponse(Raw.CreateTeam(options));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int organizationId) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationId));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int organizationId, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationId, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(int organizationId, int page, int perPage) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationId, page, perPage));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string organizationAlias) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationAlias));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string organizationAlias, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationAlias, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        public GitHubTeamListResponse GetTeams(string organizationAlias, int page, int perPage) {
            return new GitHubTeamListResponse(Raw.GetTeams(organizationAlias, page, perPage));
        }

    }

}