using Skybrud.Social.GitHub.Options.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

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

    }

}