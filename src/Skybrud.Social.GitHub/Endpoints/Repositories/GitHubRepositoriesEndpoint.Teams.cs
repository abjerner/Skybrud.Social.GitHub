using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Teams;
using Skybrud.Social.GitHub.Options.Repositories.Teams;
using Skybrud.Social.GitHub.Responses;
using Skybrud.Social.GitHub.Responses.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        #region Add team(...)

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repositoryOwner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="teamAlias">The alias of the team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public GitHubResponse AddTeam(string repositoryOwner, string repositoryAlias, string teamAlias, GitHubTeamPermission permission) {
            return new GitHubResponse(Raw.AddTeam(repositoryOwner, repositoryAlias, teamAlias, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="team">The team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public GitHubResponse AddTeam(GitHubRepositoryBase repository, GitHubTeamBase team, GitHubTeamPermission permission) {
            return new GitHubResponse(Raw.AddTeam(repository, team, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public GitHubResponse AddTeam(GitHubAddTeamsOptions options) {
            return new GitHubResponse(Raw.AddTeam(options));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repositoryOwner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="teamAlias">The alias of the team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<GitHubResponse> AddTeamAsync(string repositoryOwner, string repositoryAlias, string teamAlias, GitHubTeamPermission permission) {
            return new GitHubResponse(await Raw.AddTeamAsync(repositoryOwner, repositoryAlias, teamAlias, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="team">The team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<GitHubResponse> AddTeamAsync(GitHubRepositoryBase repository, GitHubTeamBase team, GitHubTeamPermission permission) {
            return new GitHubResponse(await Raw.AddTeamAsync(repository, team, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<GitHubResponse> AddTeamAsync(GitHubAddTeamsOptions options) {
            return new GitHubResponse(await Raw.AddTeamAsync(options));
        }

        #endregion

        #region GetTeams(...)

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public GitHubTeamListResponse GetTeams(string owner, string repositoryAlias) {
            return new GitHubTeamListResponse(Raw.GetTeams(owner, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of teams to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public GitHubTeamListResponse GetTeams(string owner, string repositoryAlias, int perPage, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(owner, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of teams of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public GitHubTeamListResponse GetTeams(GitHubRepositoryBase repository) {
            return new GitHubTeamListResponse(Raw.GetTeams(repository));
        }

        /// <summary>
        /// Returns a list of teams of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of teams to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public GitHubTeamListResponse GetTeams(GitHubRepositoryBase repository, int perPage, int page) {
            return new GitHubTeamListResponse(Raw.GetTeams(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTeamListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public GitHubTeamListResponse GetTeams(GitHubGetTeamsOptions options) {
            return new GitHubTeamListResponse(Raw.GetTeams(options));
        }

        #endregion

    }

}