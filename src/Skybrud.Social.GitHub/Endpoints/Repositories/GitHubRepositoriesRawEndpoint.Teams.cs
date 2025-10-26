using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Teams;
using Skybrud.Social.GitHub.Options.Repositories.Teams;

#pragma warning disable CA1510

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        #region Add team(...)

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repositoryOwner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="teamAlias">The alias of the team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public IHttpResponse AddTeam(string repositoryOwner, string repositoryAlias, string teamAlias, GitHubTeamPermission permission) {
            if (string.IsNullOrWhiteSpace(repositoryOwner)) throw new ArgumentNullException(nameof(repositoryOwner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(teamAlias)) throw new ArgumentNullException(nameof(teamAlias));
            return Client.GetResponse(new GitHubAddTeamsOptions(repositoryOwner, repositoryAlias, teamAlias, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="team">The team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public IHttpResponse AddTeam(GitHubRepositoryBase repository, GitHubTeamBase team, GitHubTeamPermission permission) {
            return Client.GetResponse(new GitHubAddTeamsOptions(repository, team, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public IHttpResponse AddTeam(GitHubAddTeamsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repositoryOwner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="teamAlias">The alias of the team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<IHttpResponse> AddTeamAsync(string repositoryOwner, string repositoryAlias, string teamAlias, GitHubTeamPermission permission) {
            if (string.IsNullOrWhiteSpace(repositoryOwner)) throw new ArgumentNullException(nameof(repositoryOwner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(teamAlias)) throw new ArgumentNullException(nameof(teamAlias));
            return await Client.GetResponseAsync(new GitHubAddTeamsOptions(repositoryOwner, repositoryAlias, teamAlias, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="team">The team.</param>
        /// <param name="permission">The permission to set for the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<IHttpResponse> AddTeamAsync(GitHubRepositoryBase repository, GitHubTeamBase team, GitHubTeamPermission permission) {
            return await Client.GetResponseAsync(new GitHubAddTeamsOptions(repository, team, permission));
        }

        /// <summary>
        /// Adds a team to a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/teams/teams?apiVersion=2022-11-28#add-or-update-team-repository-permissions</cref>
        /// </see>
        public async Task<IHttpResponse> AddTeamAsync(GitHubAddTeamsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return await Client.GetResponseAsync(options);
        }

        #endregion

        #region GetTeams(...)

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public IHttpResponse GetTeams(string owner, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return Client.GetResponse(new GitHubGetTeamsOptions(owner, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of teams to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public IHttpResponse GetTeams(string owner, string repositoryAlias, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return Client.GetResponse(new GitHubGetTeamsOptions(owner, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of teams of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public IHttpResponse GetTeams(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return Client.GetResponse(new GitHubGetTeamsOptions(repository));
        }

        /// <summary>
        /// Returns a list of teams of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of teams to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public IHttpResponse GetTeams(GitHubRepositoryBase repository, int perPage, int page) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return Client.GetResponse(new GitHubGetTeamsOptions(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-teams</cref>
        /// </see>
        public IHttpResponse GetTeams(GitHubGetTeamsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}